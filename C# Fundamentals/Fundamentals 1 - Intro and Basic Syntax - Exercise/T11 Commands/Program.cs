using System;

namespace T11_Commands
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 0; i < n; i++)
            {
                double capsuePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capuslesCount = int.Parse(Console.ReadLine());

                double totalPerOrder = (days * capuslesCount) * capsuePrice;

                Console.WriteLine($"The price for the coffee is: ${totalPerOrder:f2}");

                total += totalPerOrder;

                capsuePrice = 0;
                days = 0;
                capuslesCount = 0;
                totalPerOrder = 0;
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
