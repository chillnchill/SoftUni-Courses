using System;

namespace T11_Math_operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            string mathSymbol = Console.ReadLine();
            int numberTwo = int.Parse(Console.ReadLine());

            mathFunction(numberOne, mathSymbol, numberTwo);
        }

        private static void mathFunction(int a, string b, int c)
        {
            int result = 0;

            if (b == "+")
            {
                result = a + c;
            }
            else if (b == "-")
            {
                result = a - c;
            }
            else if (b == "*")
            {
                result = a * c;
            }
            else
            {
                result = a / c;
            }

            Console.WriteLine(result);
        }
    }
}
