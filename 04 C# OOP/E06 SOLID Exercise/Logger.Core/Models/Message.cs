using Logger.Core.Enums;
using Logger.Core.Exceptions;
using Logger.Core.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Models
{
    public class Message : IMessage
    {
        private string messageText;
        private string dateTime;

        public Message(string dateTime, ReportLevel reportLevel, string messageText)
        {
            DateTime = dateTime;
            ReportLevel = reportLevel;
            MessageText = messageText;
        }

        public string DateTime { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public string MessageText
        {
            get => messageText;
            private set
            {
                if (string.IsNullOrWhiteSpace(messageText))
                {
                    throw new EmptyMessageExceptions();
                }
                messageText = value;
            }
        }
    }
}
