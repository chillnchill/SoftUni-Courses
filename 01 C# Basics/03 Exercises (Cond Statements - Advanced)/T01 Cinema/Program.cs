using System;

namespace T01_Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double price = 0;

            switch (type)
            {
                case "Premiere":
                    price = 12.00; break;
                case "Normal":
                    price = 7.50; break;
                case "Discount":
                    price = 5.00; break;
            }
            double total = (rows * columns) * price;
            Console.WriteLine($"{total:F2} leva");
        }
    }
}
