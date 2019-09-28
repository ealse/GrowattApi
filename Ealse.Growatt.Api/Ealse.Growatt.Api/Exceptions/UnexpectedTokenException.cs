using System;

namespace Ealse.Growatt.Api.Exceptions
{
    /// <summary>
    /// Exception thrown when an unexpected json token type is used
    /// </summary>
    public class UnexpectedTokenException : Exception
    {
        private const string defaultMessage = "Unexpected Json Token Type.";


        public UnexpectedTokenException() : base(defaultMessage)
        {
        }

        public UnexpectedTokenException(Exception innerException) : base(defaultMessage, innerException)
        {
        }
    }
}
