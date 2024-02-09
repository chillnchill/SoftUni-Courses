using System;

namespace T05_Puppy_Care
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodKg = int.Parse(Console.ReadLine());
            string foodEaten = Console.ReadLine();
            int gramsPerDay = 0;
            int gramsAvailable = foodKg * 1000;

            while (foodEaten != "Adopted")
            {
                int foodPerDay = int.Parse(foodEaten);

                gramsPerDay += foodPerDay;

                foodEaten = Console.ReadLine();
            }

            if (gramsAvailable >= gramsPerDay)
            {
                Console.WriteLine($"Food is enough! Leftovers: {gramsAvailable - gramsPerDay} grams.");
            }
            else
            {
                Console.WriteLine($"Food is not enough. You need {gramsPerDay - gramsAvailable} grams more.");
            }


        }
    }
}
