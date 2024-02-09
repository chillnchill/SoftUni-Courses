using System;

namespace T03_Mobile_operator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string destination = Console.ReadLine();
            string season = Console.ReadLine();
            int daysSpent = int.Parse(Console.ReadLine());
            double total = 0;

            
            if (season == "Winter")
            {

                switch (destination)
                {
                    case "Dubai":
                        total = (45000 * daysSpent) * 0.7;
                        break;

                    case "Sofia":
                        total = (17000 * daysSpent) * 1.25;
                        break;

                    case "London":
                        total = 24000 * daysSpent;
                        break;
                }
            }
            else
            {
                switch (destination)
                {
                    case "Dubai":
                        total = (40000 * daysSpent) * 0.7;
                        break;

                    case "Sofia":
                        total = (12500 * daysSpent) * 1.25;
                        break;

                    case "London":
                        total = 20250 * daysSpent;
                        break;
                }
            }

            if (total <= budget)
            {
                Console.WriteLine($"The budget for the movie is enough! We have {budget - total:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"The director needs {total - budget:f2} leva more!");
            }
        }
    }
}

