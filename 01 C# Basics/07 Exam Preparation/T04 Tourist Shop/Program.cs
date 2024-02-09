using System;

namespace T04_Tourist_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            double totalFood = double.Parse(Console.ReadLine());
            int totalDog = 0;
            int totalCat = 0;
            double biscuit = 0;


            for (int i = 1; i <= days; i++)
            {
                int foodEatenByDog = int.Parse(Console.ReadLine());
                int foodEatenByCat = int.Parse(Console.ReadLine());

                totalDog += foodEatenByDog;
                totalCat += foodEatenByCat;

                if (i % 3 == 0)
                {
                    biscuit += (foodEatenByDog + foodEatenByCat) * 0.1;
                }

            }


            double foodEaten = totalCat + totalDog;           
            double percentEatenFood = foodEaten / totalFood * 100;

            Console.WriteLine($"Total eaten biscuits: {Math.Round(biscuit)}gr.");
            Console.WriteLine($"{percentEatenFood:f2}% of the food has been eaten.");
            Console.WriteLine($"{totalDog / foodEaten * 100:f2}% eaten from the dog.");
            Console.WriteLine($"{totalCat / foodEaten * 100:f2}% eaten from the cat.");
        }
    }
}
