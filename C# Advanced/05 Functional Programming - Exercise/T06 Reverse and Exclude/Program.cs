using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverse = num =>
            {
                List<int> result = new List<int>();

                for (int i = num.Count - 1; i >= 0; i--)
                {
                    result.Add(num[i]);
                }
                return result;
            };

            Func<List<int>, Predicate<int>, List<int>> removeDivisible = (numbers, match) =>
            {
                List<int> result = new List<int>();


                foreach (int i in numbers)
                {
                    if (!match(i))
                    {
                        result.Add((int)i);
                    }
                }
                return result;
            };

            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int divider = int.Parse(Console.ReadLine());

            nums = removeDivisible(nums, nums => nums % divider == 0);
            nums = reverse(nums);

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
