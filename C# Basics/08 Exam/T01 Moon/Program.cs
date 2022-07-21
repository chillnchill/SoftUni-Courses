using System;

namespace T01_Moon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double speed = double.Parse(Console.ReadLine());
            double fuel = double.Parse(Console.ReadLine());
            double timeNeeded = 0;
            double fuelNeeded = 0;

            timeNeeded = (384400 * 2) / speed + 3;
            fuelNeeded = (384400 * 2) * fuel / 100;

            Console.WriteLine(Math.Ceiling(timeNeeded));
            Console.WriteLine(fuelNeeded);
        }
    }
}
