using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Print_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> ints = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    ints.Enqueue(input[i]);
                }
                
            }

            Console.Write(String.Join(", ", ints));
  
        }
    }
}
