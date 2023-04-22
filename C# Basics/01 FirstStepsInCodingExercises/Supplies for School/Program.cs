using System;

namespace Supplies_for_School
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pencilQuantity = int.Parse(Console.ReadLine());
            int markerQuantity = int.Parse(Console.ReadLine());
            int boardCleaner = int.Parse(Console.ReadLine());
            double discount = double.Parse(Console.ReadLine());

            
            double pencils = pencilQuantity * 5.80;
            double markers = markerQuantity * 7.20;
            double cleaner = boardCleaner * 1.20;

            discount = discount / 100;
            double price = pencils + markers + cleaner;
            double totalPrice = price - (price * discount);


            Console.WriteLine(totalPrice);





        }
    }
}
