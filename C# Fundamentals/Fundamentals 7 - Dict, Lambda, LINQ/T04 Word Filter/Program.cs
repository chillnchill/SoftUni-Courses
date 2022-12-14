using System;
using System.Linq;

namespace T04_Word_Filter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ")
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            foreach (string word in input)
            {
                Console.WriteLine(word);
            }

        }
    }
}
