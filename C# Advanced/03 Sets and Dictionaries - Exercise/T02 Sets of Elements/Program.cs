using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Sets_of_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();  
            HashSet<int> n = new HashSet<int>(nums[0]);
            HashSet<int> m = new HashSet<int>(nums[1]);


            for (int i = 0; i < nums[0]; i++)
            {
                int toFill = int.Parse(Console.ReadLine());
                n.Add(toFill);
            }
            for (int i = 0; i < nums[1]; i++)
            {
                int toFill = int.Parse(Console.ReadLine());
                m.Add(toFill);
            }

            foreach (int i in n)
            {
                if (m.Contains(i))
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
