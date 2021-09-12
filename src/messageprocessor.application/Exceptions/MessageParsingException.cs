using System;

namespace MessageProcessor.Application.Exceptions
{
    public class MessageParsingException : Exception
    {
        public MessageParsingException(
            string message) : base(message) { }
    }
}
