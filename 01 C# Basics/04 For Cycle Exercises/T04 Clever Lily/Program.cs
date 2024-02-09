using System;

namespace T04_Clever_Lily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());
            double sum = 0;
            

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += i * 5 - 1;
                }
                // this grows the toyPrice by one, because the cycle spins one more time, by a total of 5 times, facepalm.
                else
                {
                    sum += toyPrice;
                }
            }

            if (sum >= washerPrice)
            {
                Console.WriteLine($"Yes! {sum - washerPrice:f2}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Abs(washerPrice - sum):f2}");

            }
        }
    }
}

