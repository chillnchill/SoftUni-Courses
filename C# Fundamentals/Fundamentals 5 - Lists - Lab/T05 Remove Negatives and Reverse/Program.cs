using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Remove_Negatives_and_Reverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> initial = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            for (int i = 0; i < initial.Count; i++)
            {
                if (initial[i] < 0)
                {
                    initial.RemoveAt(i);
                    i--;
                }
            }

            initial.Reverse();

            if (initial.Count == 0)
            {
                Console.WriteLine("empty");
            }
            else
            {
                Console.WriteLine(String.Join(" ", initial));
            }
        
        }
    }
}
