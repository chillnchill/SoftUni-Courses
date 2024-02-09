using System;

namespace T04_Print_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = first; first <= second; first++)
            {
                Console.Write($"{first} ");
                sum += first;
            }
            Console.WriteLine("");
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
