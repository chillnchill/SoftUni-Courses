using System;
using System.Collections.Generic;
using System.Linq;

namespace T4._1BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList());
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse).ToList());
            bool didSheUseAll = false;
            Dictionary<string, int> drinks = new Dictionary<string, int>();
            Dictionary<string, int> preparedDrinks = new Dictionary<string, int>();
            drinks.Add("Cortado", 50);
            drinks.Add("Espresso", 75);
            drinks.Add("Capuccino", 100);
            drinks.Add("Americano", 150);
            drinks.Add("Latte", 200);
            bool isSumUsable = false;


            while (coffee.Count > 0 && milk.Count > 0)
            {
                isSumUsable = false;
                int currentMilk = milk.Pop();
                int currentSum = coffee.Dequeue() + currentMilk;

                foreach (var drink in drinks)
                {
                    if (drink.Value == currentSum)
                    {
                        if (!preparedDrinks.ContainsKey(drink.Key))
                        {
                            preparedDrinks.Add(drink.Key, 0);
                        }
                        preparedDrinks[drink.Key]++;
                        isSumUsable = true;
                    }
                }
                if (!isSumUsable)
                {
                    currentMilk -= 5;
                    milk.Push(currentMilk);
                }
            }

            if (coffee.Count == 0 && milk.Count == 0)
            {
                didSheUseAll = true;
            }

            if (didSheUseAll)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
           
            if (coffee.Count == 0)
            {
                Console.WriteLine("Coffee left: none");
            }
            else
            {
                Console.WriteLine($"Coffee left: {string.Join(", ", coffee)}");
            }

            if (milk.Count == 0)
            {
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine($"Milk left: {string.Join(", ", milk)}");
            }


            foreach (var drink in preparedDrinks.OrderBy(v => v.Value).ThenByDescending(k => k.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
