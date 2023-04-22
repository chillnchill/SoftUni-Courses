using System;
using System.Collections.Generic;
using System.Linq;

namespace T08_List_of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Predicate<int>> predicates = new List<Predicate<int>>();
            HashSet<int> dividers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToHashSet();
            int[] numbers = Enumerable.Range(1, n).ToArray();

            foreach (int divider in dividers)
            {
                predicates.Add(p => p % divider == 0);
            }

            foreach (var number in numbers)
            {
                bool isDivisible = true;

                foreach (var match in predicates)
                {
                    if (!match(number))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    Console.WriteLine($"{number} ");
                }
            }
        }
    }
}
