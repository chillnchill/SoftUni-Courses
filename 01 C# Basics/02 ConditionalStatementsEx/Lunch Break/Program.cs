using System;

namespace Lunch_Break
{
    internal class Program
    {
        static void Main(string[] args)


        {
            string showName = Console.ReadLine();
            int epDuration = int.Parse(Console.ReadLine());
            int breakDuration = int.Parse(Console.ReadLine());

            double timeForSeries = breakDuration * 5 / 8.0;

            if (timeForSeries >= epDuration)
            {
                Console.WriteLine($"You have enough time to watch {showName} and left with {Math.Ceiling(timeForSeries-epDuration)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {showName}, you need {Math.Ceiling(epDuration-timeForSeries)} more minutes.");
            }
        }
    }
}
