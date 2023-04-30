using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T03Telephony.Models.Interfaces;

namespace T03Telephony.Models
{
    public class StationaryPhone : ICallable
    {

        public string Calling(string phoneNumber)
        {
            if (!IsNumberValid(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }

        private bool IsNumberValid(string phoneNumber) => phoneNumber.All(c => char.IsDigit(c));
        
    }
}
