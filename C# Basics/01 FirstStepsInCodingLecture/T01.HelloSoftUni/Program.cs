using System;

namespace T01.HelloSoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalSquareMeters = double.Parse(Console.ReadLine());

            double singleSquareMeter = 7.61;
            double discountPrice = 0.18;
            double priceForTotalSquareMeters = singleSquareMeter * totalSquareMeters;
            double discount = priceForTotalSquareMeters * discountPrice;
            var finalPrice = priceForTotalSquareMeters - discount;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
         }

    }
}