using System;

namespace T14_Black_Flag
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int daysOfPlunder = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());
            double totalPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                totalPlunder += dailyPlunder;

                if (i % 3 == 0)
                {
                    double bonusPlunder = dailyPlunder * 0.50;
                    totalPlunder += bonusPlunder;
                }
                else if (i % 5 == 0)
                {
                    double plunderLost = totalPlunder * 0.30;
                    totalPlunder -= plunderLost;
                }
                
            }
            double percentageMissing = (totalPlunder * 100) / expectedPlunder;

            if (totalPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                Console.WriteLine($"Collected only {percentageMissing:f2}% of the plunder.");
            }
        }
    }
}
