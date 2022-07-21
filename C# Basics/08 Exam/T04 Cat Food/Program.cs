using System;

namespace T04_Cat_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int catCount = int.Parse(Console.ReadLine());
            
            int smallCats = 0;
            int largeCats = 0;
            int hugeCats = 0;
            double totalGrams = 0;
            double price = 0;

            for (int i = 0; i < catCount; i++)
            {
                double gramsOfFoodEaten = double.Parse(Console.ReadLine());

                if (gramsOfFoodEaten >= 100 && gramsOfFoodEaten < 200)
                {
                    smallCats++;
                }
                else if (gramsOfFoodEaten >= 200 && gramsOfFoodEaten < 300)
                {
                    largeCats++;
                }
                else if (gramsOfFoodEaten >= 300 && gramsOfFoodEaten < 400)
                {
                    hugeCats++;
                }
                totalGrams += gramsOfFoodEaten;
            }
            price = (totalGrams / 1000) * 12.45; 
            Console.WriteLine($"Group 1: {smallCats} cats.");
            Console.WriteLine($"Group 2: {largeCats} cats.");
            Console.WriteLine($"Group 3: {hugeCats} cats.");
            Console.WriteLine($"Price for food per day: {price:f2} lv.");
        }
    }
}
