using System;

namespace T05_Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            
            string destination = "";
            string spot = "";

            if (budget <= 100)
            {
                destination = "Bulgaria";

            }
            else if (budget <= 1000)
            {
                destination = "Balkans";
            }
            else
            {
                destination = "Europe";
            }

            switch (destination)
            {
                case "Bulgaria":
                    if (season == "summer")
                    {
                        budget = budget * 0.30;
                    }
                    else if (season == "winter")
                    {
                        budget = budget * 0.70;
                    }
                    break;
                case "Balkans":
                    if (season == "summer")
                    {
                        budget = budget * 0.40;
                    }
                    else if (season == "winter")
                    {
                        budget = budget * 0.80;
                    }
                    break;
                case "Europe":
                    budget = budget * 0.90;
                    break;



            }

            if (season == "summer" && destination != "Europe")
            {
                spot = "Camp";
            }
            else 
            {
                spot = "Hotel";
            }

            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{spot} - {budget:f2}");
        }
    }
}
