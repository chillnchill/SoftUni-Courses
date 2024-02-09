using System;

namespace Т09_Ski_Trip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //▪ "room for one person" – 18.00 лв за нощувка
            //▪ "apartment" – 25.00 лв за нощувка
            //▪ "president apartment" – 35.00 лв за нощувка

            int daysSpent = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string assesment = Console.ReadLine();

            daysSpent = daysSpent - 1;
            double price = 0;

            switch (roomType)
            {
                case "room for one person":
                    price = daysSpent * 18.00;
                    break;
                case "apartment":
                    price = daysSpent * 25.00;
                    if (daysSpent < 10)
                    {
                        price -= price * 0.30;
                    }
                    else if (daysSpent >= 10 && daysSpent <= 15)
                    {
                        price -= price * 0.35;
                    }
                    else
                    {
                        price -= price * 0.50;
                    }
                    break;
                case "president apartment":
                    price = daysSpent * 35.00;
                    if (daysSpent < 10)
                    {
                        price -= price * 0.10;
                    }
                    else if (daysSpent >= 10 && daysSpent <= 15)
                    {
                        price -= price * 0.15;
                    }
                    else
                    {
                        price -= price * 0.20;
                    }
                    break;
            }

            if (assesment == "positive")
            {
                price += price * 0.25;
                Console.WriteLine($"{price:f2}");
            }
            else
            {
                price -= price * 0.10;
                Console.WriteLine($"{price:f2}");
            }
            
        }
    }
}
