using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_Find_Evens_Or_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            List<int> range = new List<int>();
            List<int> result = new List<int>();
            string action = Console.ReadLine();

            Predicate<int> even = x => x % 2 == 0;
            Predicate<int> odd = x => x % 2 != 0;

            for (int i = nums[0]; i <= nums[1]; i++)
            {
                range.Add(i);
            }

            if (action == "even")
            {
                result.AddRange(range.FindAll(even));
            }
            else
            {
                result.AddRange(range.FindAll(odd));
            }

            Console.WriteLine(String.Join(" ", result));
        }
    }
}
