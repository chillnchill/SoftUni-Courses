using System;

namespace t00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodKg = int.Parse(Console.ReadLine());

            foodKg %= 3;

            Console.WriteLine(foodKg);
        }
    }
}
