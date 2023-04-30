using Logger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Models.Interfaces
{
    using Enums;
    public interface IMessage
    {
        public string MessageText { get; }
        public string DateTime { get; }

        public ReportLevel ReportLevel { get; }
    }
}
