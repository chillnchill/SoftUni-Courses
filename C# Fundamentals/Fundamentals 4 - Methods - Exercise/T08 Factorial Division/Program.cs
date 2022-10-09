using System;

namespace T08_Factorial_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());

            int factorialOne = FindingFactorial(first);
            int factorialTwo = FindingFactorial(second);
            Console.WriteLine($"{factorialOne / factorialTwo:f2}");
        }

        private static int FindingFactorial(int numberToFactorial)
        {
            int number = numberToFactorial;

            for (int i = numberToFactorial - 1; i >= 1; i--)
            {
                number *= i;
            }
            return number;
        }
    }
}
