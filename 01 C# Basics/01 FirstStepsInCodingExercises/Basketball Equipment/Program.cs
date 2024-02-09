using System;

namespace Basketball_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int yearTax = int.Parse(Console.ReadLine());

            double shoes = yearTax - (yearTax * 0.4);
            double jersey = shoes - (shoes * 0.2);
            double ball = jersey / 4;
            double acc = ball / 5;

            double totalPrice = yearTax + shoes + jersey + ball + acc;


            Console.WriteLine(totalPrice);

        }

    }
}
