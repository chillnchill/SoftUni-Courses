using System;

namespace T05_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string order = Console.ReadLine();           
            int quantity = int.Parse(Console.ReadLine());
            double price = 0;

            if (order == "coffee")
            {
                price = 1.50;
                calculation(quantity, price);
            }
            else if (order == "water")
            {
                price = 1.00;
                calculation(quantity, price);
            }
            else if (order == "coke")
            {
                price = 1.40;
                calculation(quantity, price);
            }
            else if (order == "snacks")
            {
                price = 2.00;
                calculation(quantity, price);
            }

        }

        private static void calculation(double a, double b)
        {
            Console.WriteLine($"{a*b:f2}");
        }
    }
}
