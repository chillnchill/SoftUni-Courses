using System;
using System.Collections.Generic;
using System.Linq;

namespace T07_Append_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).Reverse().ToList();

            List<int> reversed = new List<int>(); 

            foreach (string number in numbers)
            {
                reversed.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            }

            Console.WriteLine(String.Join(" ", reversed));
        }
    }
}
