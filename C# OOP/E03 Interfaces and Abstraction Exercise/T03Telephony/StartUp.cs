using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using T03Telephony.Models;
using T03Telephony.Models.Interfaces;

namespace T03Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            foreach (string number in numbers)
            {
                ICallable phone;

                if (number.Length == 10)
                {
                    phone = new Smartphone();

                }
                else
                {
                    phone = new StationaryPhone();

                }

                try
                {
                    Console.WriteLine(phone.Calling(number));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (string site in urls)
            {
                IBrowsable smartPhone = new Smartphone();
                try
                {
                    Console.WriteLine(smartPhone.Browsing(site));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

        }
    }
}
