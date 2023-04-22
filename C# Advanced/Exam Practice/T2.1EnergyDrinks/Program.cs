using System;
using System.Collections.Generic;
using System.Linq;

namespace T2._1EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> mgCaffeine = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Queue<int> energyDrink = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            int totalCaffeine = 0;

            while (mgCaffeine.Count > 0 && energyDrink.Count > 0)
            {

                int currentMg = mgCaffeine.Pop();
                int currentDrink = energyDrink.Dequeue();
                int currentDrinkCaffeine = currentMg * currentDrink;

                if (totalCaffeine + currentDrinkCaffeine <= 300)
                {
                    totalCaffeine += currentDrinkCaffeine;
                }
                else
                {

                    energyDrink.Enqueue(currentDrink);
                    totalCaffeine -= 30;
                    if (totalCaffeine < 0)
                    {
                        totalCaffeine = 0;
                    }
                    continue;
                }

            }

            if (energyDrink.Count > 0)
            {
                Console.WriteLine($"Drinks left: {String.Join(", ", energyDrink)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {totalCaffeine} mg caffeine.");
        }
    }
}
