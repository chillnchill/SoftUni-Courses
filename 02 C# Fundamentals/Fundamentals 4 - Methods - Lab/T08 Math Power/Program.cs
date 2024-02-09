using System;

namespace T08_Math_Power
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double num = double.Parse(Console.ReadLine());
            double toPower = double.Parse(Console.ReadLine());

            putIntToPower(num, toPower);
        }

        private static void putIntToPower(double num, double toPower)
        {
            Console.WriteLine(Math.Pow(num, toPower));
        }
    }
}
