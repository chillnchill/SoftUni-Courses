using System;

namespace T06_Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());

            formulaForArea(a, b);
        }

        private static void formulaForArea(double A, double B)
        {
            Console.WriteLine(A * B);
        }
    }
}
