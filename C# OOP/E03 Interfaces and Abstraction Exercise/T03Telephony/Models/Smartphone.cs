using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T03Telephony.Models.Interfaces;

namespace T03Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browsing(string url)
        {
            if (!IsURLValid(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

       

        public string Calling(string phoneNumber)
        {
            if (!IsNumberValid(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }

        private bool IsNumberValid(string phoneNumber) => phoneNumber.All(c => char.IsDigit(c));
        private bool IsURLValid(string url) => url.All(c => !Char.IsDigit(c));
    }
}
