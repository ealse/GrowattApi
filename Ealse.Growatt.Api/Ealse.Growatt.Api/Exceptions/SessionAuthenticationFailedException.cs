using System;

namespace Ealse.Growatt.Api.Exceptions
{
    /// <summary>
    /// Exception thrown when authenticating failed
    /// </summary>
    public class SessionAuthenticationFailedException : Exception
    {
        private const string defaultMessage = "Could not login to Growatt server.";

        public SessionAuthenticationFailedException() : base(defaultMessage)
        {
        }

        public SessionAuthenticationFailedException(Exception innerException, string message = defaultMessage) : base(message, innerException)
        {
        }
    }
}
