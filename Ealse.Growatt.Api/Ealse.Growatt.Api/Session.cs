using Ealse.Growatt.Api.Helpers;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.Json;
using System.Net;
using System.Linq;
using Ealse.Growatt.Api.Converters;
using Ealse.Growatt.Api.Models;

namespace Ealse.Growatt.Api
{
    public partial class Session : IDisposable
    {
        public string Username { get; private set; }

        public string Md5Password { get; private set; }

        public Uri GrowattApiBaseUrl => new Uri("https://server.growatt.com/");

        public string UserAgent => "";

        private readonly CookieContainer cookieContainer = new CookieContainer();

        public bool IsAuthenticated { get; set; }

        private readonly HttpClient client;

        public Session(string username, string password)
        {
            Username = username;
            Md5Password = password.CalculateMD5Hash();

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
                var userlogin = await GetNewSession();
                IsAuthenticated = userlogin.IsAuthenticated;

            }
            catch (Exception ex)
            {
                throw new Exceptions.SessionAuthenticationFailedException(ex);
            }
        }

        private async Task<LoginInfo> GetNewSession()
        {

            var content = new FormUrlEncodedContent(new[]
            {
                    new KeyValuePair<string, string>("userName", Username),
                    new KeyValuePair<string, string>("password", Md5Password),
                });

            var response = client.PostAsync(LoginRelativeUrl, content).Result;

            if (response.IsSuccessStatusCode)
            {
                // Request was successful
                var responseString = await response.Content.ReadAsStringAsync();
                try
                {
                    return JsonSerializer.Deserialize<LoginInfo>(GetRootJsonObject(responseString));
                }
                catch
                {
                    throw new Exceptions.SessionAuthenticationFailedException();
                }
            }

            throw new Exceptions.SessionAuthenticationFailedException();
        }

        /// <summary>
        /// Sends a message to the Tado API and returns the provided object of type T with the response
        /// </summary>
        /// <typeparam name="T">Object type of the expected response</typeparam>
        /// <param name="uri">Uri of the webservice to send the message to</param>
        /// <param name="expectedHttpStatusCode">The expected Http result status code. Optional. If provided and the webservice returns a different response, the return type will be NULL to indicate failure.</param>
        /// <returns>Typed entity with the result from the webservice</returns>
        protected virtual async Task<T> GetMessageReturnResponse<T>(Uri uri, HttpStatusCode? expectedHttpStatusCode = null)
        {
            if (!IsAuthenticated || !cookieContainer.GetCookies(GrowattApiBaseUrl).Cast<Cookie>().Any(cookie => !cookie.Expired))
            {
                await Authenticate();
            }

            var options = new JsonSerializerOptions
            {
                Converters = { new PlantDetailDayDataConverter(), new PlantDetailMonthDataConverter(), new PlantDetailYearDataConverter(), new PlantDetailTotalDataConverter() }
            };


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
                            var responseString = await response.Content.ReadAsStringAsync();

                            var responseEntity = JsonSerializer.Deserialize<T>(GetRootJsonObject(responseString), options);
                            return responseEntity;
                        }
                        return default;
                    }
                }
                catch (Exception ex)
                {
                    // Request was not successful. throw an exception
                    throw new Exceptions.RequestFailedException(uri, ex);
                }
            }
        }

        private string GetRootJsonObject(string jsonResponse)
        {
            if (string.IsNullOrEmpty(jsonResponse))
            {
                return string.Empty;
            }

            using (JsonDocument document = JsonDocument.Parse(jsonResponse))
            {
                document.RootElement.TryGetProperty("back", out JsonElement elementWithBackProperty);
                var result = elementWithBackProperty.ToString();
                return string.IsNullOrEmpty(result) ? jsonResponse : result;
            }
        }
    }
}