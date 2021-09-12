﻿using System;

namespace MessageProcessor.Application.Models.MessageFormatA
{
    public class Input : BaseMessageFormat
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public DateTime SendTime { get; set; }
    }
}
