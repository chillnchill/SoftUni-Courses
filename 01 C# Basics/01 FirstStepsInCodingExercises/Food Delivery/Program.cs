using System;

namespace Food_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double chicken = chickenMenu * 10.35;
            double fish = fishMenu * 12.40;
            double vegan = veganMenu * 8.15;

            double price = chicken + fish + vegan;
            double desert = price * 0.20;


            double totalPrice = price + desert + 2.50;

            Console.WriteLine(totalPrice);
        }
    }
}
