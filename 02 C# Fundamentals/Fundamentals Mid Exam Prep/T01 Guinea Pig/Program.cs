using System;

namespace T01_Guinea_Pig
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double foodKg = double.Parse(Console.ReadLine());
            double hayKg = double.Parse(Console.ReadLine());
            double coverKg = double.Parse(Console.ReadLine());
            double puppyKg = double.Parse(Console.ReadLine());

            int month = 30;
            double foodInGrams = foodKg * 1000;
            double hayInGrams = hayKg * 1000;
            double coverInGrams = coverKg * 1000;
            double puppyInGrams = puppyKg * 1000;
            double coverPerThreeDays = puppyInGrams / 3;

            for (int i = 1; i <= month; i++)
            {
                foodInGrams -= 300;

                if (i % 2 == 0)
                {
                    hayInGrams -= foodInGrams * 0.05;
                }
                if (i % 3 == 0)
                {
                    coverInGrams -= Math.Round(coverPerThreeDays, 2);
                }

                if (foodInGrams <= 0 || hayInGrams <= 0 || coverInGrams <= 0)
                {
                    Console.WriteLine("Merry must go to the pet store!");
                    return;
                }

            }

            Console.WriteLine($"Everything is fine! Puppy is happy! " +
                $"Food: {foodInGrams / 1000:f2}, Hay: {hayInGrams / 1000:f2}, Cover: {coverInGrams / 1000:f2}.");

        }
    }
}
