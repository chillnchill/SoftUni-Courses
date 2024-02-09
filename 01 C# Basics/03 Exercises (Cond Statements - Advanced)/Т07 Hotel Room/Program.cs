using System;

namespace Т07_Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightsSpent = int.Parse(Console.ReadLine());

            double apartmentPrice = 0;
            double studioPrice = 0;

            if (month == "May" || month == "October")
            {
                studioPrice = nightsSpent * 50;
                apartmentPrice = nightsSpent * 65;

                if (nightsSpent <= 14 && nightsSpent > 7)
                {
                    studioPrice = studioPrice - (studioPrice * 0.05);
                }
                else if (nightsSpent > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.30);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
                
            }

            else if (month == "June" || month == "September")
            {
                studioPrice = nightsSpent * 75.20;
                apartmentPrice = nightsSpent * 68.70;

                if (nightsSpent > 14)
                {
                    studioPrice = studioPrice - (studioPrice * 0.20);
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
            }
            
            else 
            {
                studioPrice = nightsSpent * 76;
                apartmentPrice = nightsSpent * 77;

                if (nightsSpent > 14)
                {
                    apartmentPrice = apartmentPrice - (apartmentPrice * 0.10);
                }
            }



            Console.WriteLine($"Apartment: {apartmentPrice:F2} lv.");
            Console.WriteLine($"Studio: {studioPrice:f2} lv.");
        }
    }
}
