using System;

namespace T03_New_House
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int flowerCount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double discount = 0;
            double total = 0;
            double added = 0;

            switch (flowers)
            {
                case "Roses":
                    total = flowerCount * 5;

                    if (flowerCount > 80)
                    {
                        discount = total * 0.10;
                    }

                    break;

                case "Dahlias":
                    total = flowerCount * 3.80;

                    if (flowerCount > 90)
                    {
                        discount = total * 0.15;
                    }

                    break;
                case "Tulips":
                    total = flowerCount * 2.80;

                    if (flowerCount > 80)
                    {
                        discount = total * 0.15;
                    }

                    break;
                case "Narcissus":
                    total = flowerCount * 3;

                    if (flowerCount < 120)
                    {
                        added = total * 0.15;
                    }

                    break;
                case "Gladiolus":
                    total = flowerCount * 2.50;

                    if (flowerCount < 80)
                    {
                        added = total * 0.20;
                    }

                    break;
            }
            if (discount > 0)
            {
                total = total - discount;
            }
            else if (added > 0)
            {
                total = total + added;
            }


            if (budget >= total)
                {
                    Console.WriteLine($"Hey, you have a great garden with {flowerCount} {flowers} and {budget - total:f2} leva left.");
                }
            else
                {
                    Console.WriteLine($"Not enough money, you need {total - budget:f2} leva more.");
                }
            

        }
    }
}
