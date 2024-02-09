using System;

namespace T02_Safari
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int numberOfNights = int.Parse(Console.ReadLine());
            double priceForOneNight = double.Parse(Console.ReadLine());
            double addedExpensesPercent = int.Parse(Console.ReadLine());
            


            double priceForAllNights = numberOfNights * priceForOneNight;
            addedExpensesPercent = addedExpensesPercent / 100;
            addedExpensesPercent *= budget; 

            if (numberOfNights > 7)
            {
                priceForAllNights -= (priceForAllNights * 0.05);
            }

            priceForAllNights += addedExpensesPercent;
            
            if (priceForAllNights <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - priceForAllNights:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{priceForAllNights - budget:f2} leva needed.");
            }
        
        }
    }
}
