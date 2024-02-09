using System;

namespace Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double GPU = double.Parse(Console.ReadLine());
            double Processors = double.Parse(Console.ReadLine());
            double RAM = double.Parse(Console.ReadLine());


            double gpuTotal = GPU * 250;
            double processorsTotal = gpuTotal * 0.35;
            double RAMTotal = gpuTotal * 0.10;

            double total = gpuTotal + (processorsTotal * Processors) + (RAM * RAMTotal); 

            if (GPU > Processors)
            {
                total = total * 0.85;
            }

            double left = Math.Abs(budget - total);

            if (total <= budget)
            {
                Console.WriteLine($"You have {left:F2} leva left!");  
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {left:F2} leva more!");
            }

        }
    }
}
