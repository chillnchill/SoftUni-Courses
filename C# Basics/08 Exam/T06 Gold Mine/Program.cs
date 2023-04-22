using System;

namespace T06_Gold_Mine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMines = int.Parse(Console.ReadLine());
            double goldAtSingleLocation = 0;

            for (int i = 0; i < numberOfMines; i++)
            {
                double estimatedGoldAmount = double.Parse(Console.ReadLine());
                int daysAtOneLocation = int.Parse(Console.ReadLine());
                if (goldAtSingleLocation > 0)
                {
                    goldAtSingleLocation = 0;
                }

                for (int j = 0; j < daysAtOneLocation; j++)
                {
                    double goldPerDay = double.Parse(Console.ReadLine());
                    goldAtSingleLocation += goldPerDay;
                }

                goldAtSingleLocation /= daysAtOneLocation;

                if (goldAtSingleLocation >= estimatedGoldAmount)
                {
                    Console.WriteLine($"Good job! Average gold per day: {goldAtSingleLocation:f2}.");
                }
                else
                {
                    Console.WriteLine($"You need {estimatedGoldAmount - goldAtSingleLocation:f2} gold.");
                }
            }
        }
    }
}
