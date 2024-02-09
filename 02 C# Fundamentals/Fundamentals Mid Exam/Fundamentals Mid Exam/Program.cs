using System;

namespace Fundamentals_Mid_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flourPriceSingle = double.Parse(Console.ReadLine());
            double eggPriceSingle = double.Parse(Console.ReadLine());
            double apronPriceSingle = double.Parse(Console.ReadLine());

            double additionalAprons = (Math.Ceiling(students * 1.20));
            double apronPrice = additionalAprons * apronPriceSingle;
            double eggPrice = students * (eggPriceSingle * 10);
            double freeFlourPacks = Math.Floor(students / 5.0);
            double flourPrice = (students - freeFlourPacks) * flourPriceSingle;

            double total = apronPrice + eggPrice + flourPrice;

            if (total <= budget)
            {
                Console.WriteLine($"Items purchased for {total:f2}$.");
            }
            else
            {
                Console.WriteLine($"{total - budget:f2}$ more needed.");
            }



        }
    }
}
