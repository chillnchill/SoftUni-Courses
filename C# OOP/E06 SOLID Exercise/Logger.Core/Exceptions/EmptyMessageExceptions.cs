using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Core.Exceptions
{
    public class EmptyMessageExceptions : Exception
    {
        private const string DefaultMessage = "Message text cannot be null or whitespace!"
        public EmptyMessageExceptions() : base(DefaultMessage)
        {

        }

        public EmptyMessageExceptions(string message)
            : base(message)
        {
            
        }
    }
}
