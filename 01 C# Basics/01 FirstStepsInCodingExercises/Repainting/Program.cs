using System;

namespace Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using System;

namespace Supplies_for_School
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                int nylonQuantity = int.Parse(Console.ReadLine());
                double paintQuantity = int.Parse(Console.ReadLine());
                int thinnerLiters = int.Parse(Console.ReadLine());

                paintQuantity = paintQuantity + paintQuantity * 0.10;
                nylonQuantity = nylonQuantity + 2;

                double nylonPrice = nylonQuantity * 1.5;
                double paintPrice = paintQuantity * 14.50;
                double thinnerPrice = thinnerLiters * 5.00;

                double materialSum = nylonPrice + paintPrice + thinnerPrice + 0.40;

                int workHours = int.Parse(Console.ReadLine());

                double pricePerHour = materialSum * 0.3;
                double worksSum = pricePerHour * workHours;
                double totalSum = materialSum + worksSum;

                Console.WriteLine(totalSum);


            }
        }
    }

}
    }
}
