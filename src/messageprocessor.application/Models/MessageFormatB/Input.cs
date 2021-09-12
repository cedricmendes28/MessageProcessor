using System;

namespace MessageProcessor.Application.Models.MessageFormatB
{
    public class Input : BaseMessageFormat
    {
        public uint Timestamp { get; set; }
        public Message Message { get; set; }
        public Source Source { get; set; }
    }

    public class Message
    {
        public string Type { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
    }

    public class Source
    {
        public string Type { get; set; }
        public string UserId { get; set; }
    }
}
