using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            Action<List<int>> add = num =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i]++;
                }
            };

            Action<List<int>> multiply = num =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i] *= 2;
                }
            };

            Action<List<int>> subtract = num =>
            {
                for (int i = 0; i < nums.Count; i++)
                {
                    nums[i]--;
                }
            };

            Action<List<int>> print = num =>
            {

                    Console.WriteLine(String.Join(" ", nums));
            };


            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "end")
                {
                    break;
                }

                switch (commands)
                {
                    case "add":
                        add(nums);
                        break;
                    case "multiply":
                        multiply(nums);
                        break;
                    case "subtract":
                        subtract(nums);
                        break;
                    case "print":
                        print(nums);
                        break;
                }
            }
        }
    }
}
