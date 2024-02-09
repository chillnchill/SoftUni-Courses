using System;

namespace Toy_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double tripPrice = double.Parse(Console.ReadLine());
            int puzzleCount = int.Parse(Console.ReadLine());
            int dollCount = int.Parse(Console.ReadLine());
            int teddyCount = int.Parse(Console.ReadLine());
            int minionCount = int.Parse(Console.ReadLine());
            int truckCount = int.Parse(Console.ReadLine());

            double puzzle = 2.60;
            double doll = 3;
            double teddy = 4.10;
            double minion = 8.20;
            double truck = 2;
            
            double totalOrders = puzzleCount + dollCount + teddyCount + minionCount + truckCount;
            double totalPrice = (puzzleCount * puzzle) + (dollCount * doll) + (teddyCount * teddy) + (minionCount * minion) + (truckCount * truck);
            double discount = totalPrice * 0.25;
            if (totalOrders >= 50)
            {
                totalPrice = totalPrice - discount;
            }

            double rent = totalPrice * 0.10;

            totalPrice = totalPrice - rent;
            double totalLeft = Math.Abs(totalPrice - tripPrice);
            if (totalPrice >= tripPrice)

            {
                Console.WriteLine($"Yes! {totalLeft:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {totalLeft:F2} lv needed.");
            }

            


        }
    }
}
