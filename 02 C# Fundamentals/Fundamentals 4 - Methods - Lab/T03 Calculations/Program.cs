using System;

namespace T03_Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string function = Console.ReadLine();
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());

            if (function == "add")
            {
                add(numberOne, numberTwo);
            }
            else if (function == "subtract")
            {
                substract(numberOne, numberTwo);
            }
            else if (function == "multiply")
            {
                multiply(numberOne, numberTwo);
            }
            else if (function == "divide")
            {
                divide(numberOne, numberTwo);
            }

        }
        static void add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        static void substract(int a, int b)
        {
            Console.WriteLine(a - b);
        }
        static void multiply(int a, int b)
        {
            Console.WriteLine(a * b);
        }
        static void divide(int a, int b)
        {
            Console.WriteLine(a / b);
        }
    }
}
