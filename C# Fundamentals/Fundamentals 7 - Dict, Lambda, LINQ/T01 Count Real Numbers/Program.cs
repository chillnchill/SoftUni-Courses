using System;
using System.Collections.Generic;
using System.Linq;

namespace T01_Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> occurancesByNumber = new SortedDictionary<int, int>();

            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            foreach (int number in numbers)
            {
                if (!occurancesByNumber.ContainsKey(number))
                {
                    occurancesByNumber.Add(number, 0);
                }

                occurancesByNumber[number]++;
            }

            foreach (var occuranceByNumber in occurancesByNumber)
            {
                Console.WriteLine($"{occuranceByNumber.Key} -> {occuranceByNumber.Value}");
            }
        }
    }
}
