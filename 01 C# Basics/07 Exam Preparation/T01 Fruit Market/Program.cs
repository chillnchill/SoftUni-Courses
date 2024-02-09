using System;

namespace T01_Fruit_Market
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double strawberryPrice = double.Parse(Console.ReadLine());
            double bananaKg = double.Parse(Console.ReadLine());
            double orangesKg = double.Parse(Console.ReadLine());
            double raspberryKg = double.Parse(Console.ReadLine());
            double strawberryKg = double.Parse(Console.ReadLine());

            double raspberryPrice = strawberryPrice / 2;
            double orangesPrice = raspberryPrice - raspberryPrice * 0.40;
            double bananaPrice = raspberryPrice - raspberryPrice * 0.80;
            

            double strawberryTotal = strawberryKg * strawberryPrice;
            double bananaTotal = bananaKg * bananaPrice;
            double raspberryTotal = raspberryKg * raspberryPrice;
            double orangesTotal = orangesPrice * orangesKg;
            double total = strawberryTotal + bananaTotal + raspberryTotal + orangesTotal;

            Console.WriteLine($"{total:f2}");
        }
    }
}
