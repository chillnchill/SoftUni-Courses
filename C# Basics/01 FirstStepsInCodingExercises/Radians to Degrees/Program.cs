using System;

namespace Radians_to_Degrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radians = double.Parse(Console.ReadLine());
            double Pi = 180 / Math.PI;
            double degrees = radians * Pi;

            Console.WriteLine(degrees); 
        }
    }
}
