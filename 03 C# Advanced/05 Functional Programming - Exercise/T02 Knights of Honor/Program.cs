using System;

namespace T02_Knights_of_Honor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> splitter = strings =>
            {
                foreach (string knight in strings)
                {
                    Console.WriteLine($"Sir {knight}");
                }
            };

            string[] input = Console.ReadLine().Split(' ');

            splitter(input);
        }
    }
}
