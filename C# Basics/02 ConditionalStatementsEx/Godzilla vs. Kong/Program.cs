using System;

namespace Godzilla_vs._Kong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int statist = int.Parse(Console.ReadLine());
            double statistClothing = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;

            if (statist > 150)
            {
                statistClothing = statistClothing - (statistClothing * 0.10);
            }
            // ^ this can also be done as statistClothing * 0.90; as this will be the leftover OR statist clothing *= 0.90;

            double statistExpenses = statist * statistClothing;
            double total = decor + statistExpenses;
            double totalExpenses = Math.Abs(budget - total);

 
            if (total > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {totalExpenses,0:F2} leva more.");
            }

            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with { totalExpenses,0:F2} leva left.");
            }

        }
    }
}
