using System;

namespace MessageProcessor.Application.Models.MessageFormatC
{
    public class Input : BaseMessageFormat
    {
        public string MSISDN { get; set; }
        public Message Message { get; set; }
    }

    public class Message
    {
        public string MsgText { get; set; }
        public DateTime MsgTime { get; set; }
    }
}
