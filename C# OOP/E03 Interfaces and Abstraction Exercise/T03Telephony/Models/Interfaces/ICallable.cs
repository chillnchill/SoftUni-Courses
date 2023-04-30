using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T03Telephony.Models.Interfaces
{
    public interface ICallable
    {
        string Calling(string phoneNumber);
    }
}
