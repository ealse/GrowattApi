using Ealse.Growatt.Api.Extensions;
using Ealse.Growatt.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string Username { get; private set; }

        public string Password { get; private set; }

        public Uri GrowattApiBaseUrl { get; set; } = new Uri("https://server.growatt.com/");

        public bool IsAuthenticated { get; set; }
        public string UserAgent { get; set; } = string.Empty;

        private readonly CookieContainer cookieContainer = new CookieContainer();

        private readonly HttpClient client;

        public Session(string username, string password)
        {
            Username = username;
            Password = password;

            // Add a HttpClient to the session to allow for network communication
            client = CreateHttpClient();
        }

        public void Dispose()
        {
            client?.Dispose();
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler()
            {
                CookieContainer = cookieContainer
            };

            // Create the new HTTP Client
            var httpClient = new HttpClient(handler)
            {
                BaseAddress = GrowattApiBaseUrl
            };

            if (!string.IsNullOrEmpty(UserAgent))
            {
                // Identify to the server with a specific User Agent
                httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            }

            return httpClient;
        }

        public async Task Authenticate()
        {
            try
            {
                var userLogin = await GetNewSession();
                IsAuthenticated = userLogin.IsAuthenticated;
            }
            catch (Exception ex)
            {
                throw new Exceptions.SessionAuthenticationFailedException(ex);
            }
        }

        private async Task<LoginInfo> GetNewSession()
        {
            var loginInfo = new LoginInfo
            {
                IsAuthenticated = false
            };

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("account", Username),
                new KeyValuePair<string, string>("password", Password),
                new KeyValuePair<string, string>("validateCode", string.Empty),
            });

            var response = client.PostAsync(LoginRelativeUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                // Request was successful
                var responseString = await response.Content.ReadAsStringAsync();
                if (responseString.Equals("{\"result\":1}"))
                {
                    loginInfo.IsAuthenticated = true;
                }
            }

            return loginInfo;
        }

        /// <summary>
        /// Sends a message to the Tado API and returns the provided object of type T with the response
        /// </summary>
        /// <typeparam name="T">Object type of the expected response</typeparam>
        /// <param name="uri">Uri of the webservice to send the message to</param>
        /// <param name="expectedHttpStatusCode">The expected Http result status code. Optional. If provided and the webservice returns a different response, the return type will be NULL to indicate failure.</param>
        /// <returns>Typed entity with the result from the webservice</returns>
        protected virtual async Task<string> GetMessageReturnResponse(Uri uri, HttpStatusCode? expectedHttpStatusCode = null)
        {
            if (!IsAuthenticated || !cookieContainer.GetCookies(GrowattApiBaseUrl).Cast<Cookie>().Any(cookie => !cookie.Expired))
            {
                await Authenticate();
            }

            // Construct the request towards the webservice
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                try
                {
                    // Request the response from the webservice
                    using (var response = await client.SendAsync(request))
                    {
                        if (!expectedHttpStatusCode.HasValue || (expectedHttpStatusCode.HasValue && response != null && response.StatusCode == expectedHttpStatusCode.Value))
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        throw new Exceptions.RequestFailedException(uri, new Exception("Invalid HTTP Status Code returned"));
                    }
                }
                catch (Exception ex)
                {
                    // Request was not successful. throw an exception
                    throw new Exceptions.RequestFailedException(uri, ex);
                }
            }
        }

        /// <summary>
        /// Sends a message to the Tado API and returns the provided object of type T with the response
        /// </summary>
        /// <typeparam name="T">Object type of the expected response</typeparam>
        /// <param name="uri">Uri of the webservice to send the message to</param>
        /// <param name="expectedHttpStatusCode">The expected Http result status code. Optional. If provided and the webservice returns a different response, the return type will be NULL to indicate failure.</param>
        /// <returns>Typed entity with the result from the webservice</returns>
        protected virtual async Task<string> PostMessageReturnResponse(Uri uri, HttpContent body, HttpStatusCode? expectedHttpStatusCode = null)
        {
            if (!IsAuthenticated || !cookieContainer.GetCookies(GrowattApiBaseUrl).Cast<Cookie>().Any(cookie => !cookie.Expired))
            {
                await Authenticate();
            }

            // Construct the request towards the webservice
            using (var request = new HttpRequestMessage(HttpMethod.Post, uri))
            {
                try
                {
                    // Request the response from the webservice
                    using (var response = await client.PostAsync(request.RequestUri, body))
                    {
                        if (!expectedHttpStatusCode.HasValue || (expectedHttpStatusCode.HasValue && response != null && response.StatusCode == expectedHttpStatusCode.Value))
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        throw new Exceptions.RequestFailedException(uri, new Exception("Invalid HTTP Status Code returned"));
                    }
                }
                catch (Exception ex)
                {
                    // Request was not successful. throw an exception
                    throw new Exceptions.RequestFailedException(uri, ex);
                }
            }
        }

        private async Task<responseType> GetPostResponseData<responseType>(HttpContent content, Uri uri, string jsonPath)
        {
            var response = await PostMessageReturnResponse(uri, content, HttpStatusCode.OK);
            var result = JsonSerializer.Deserialize<responseType>(response.GetPartOfJson(jsonPath));

            return result == null ? throw new Exceptions.RequestFailedException(uri, new Exception("Deserialization error")) : result;
        }

        private async Task<responseType> GetResponseData<responseType>(Uri uri, string jsonPath)
        {
            var response = await GetMessageReturnResponse(uri, HttpStatusCode.OK);
            var result = JsonSerializer.Deserialize<responseType>(response.GetPartOfJson(jsonPath));

            return result == null ? throw new Exceptions.RequestFailedException(uri, new Exception("Deserialization error")) : result;
        }
    }
}