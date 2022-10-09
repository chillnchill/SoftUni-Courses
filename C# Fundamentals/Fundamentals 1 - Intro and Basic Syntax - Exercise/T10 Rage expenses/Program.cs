using System;

namespace T10_Rage_expenses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int rageCounter = 0;
            double headsetsNeeded = 0;
            double mousesetsNeeded = 0;
            double keyboardsetsNeeded = 0;
            double displaysetsNeeded = 0;

            for (int i = 0; i < lostGames; i++)
            {
                rageCounter++;

                if (rageCounter % 2 == 0)
                {
                    headsetsNeeded += headsetPrice;
                }
                if (rageCounter % 3 == 0)
                {
                    mousesetsNeeded += mousePrice;
                }
                if (rageCounter % 6 == 0)
                {
                    keyboardsetsNeeded += keyboardPrice;
                }
                if (rageCounter % 12 == 0)
                {
                    displaysetsNeeded += displayPrice;
                }
                
                if (rageCounter == 12)
                {
                    rageCounter = 0;
                }
            }

            double totalPrice = headsetsNeeded + mousesetsNeeded + keyboardsetsNeeded + displaysetsNeeded;

            Console.WriteLine($"Rage expenses: {totalPrice:f2} lv.");

        }
    }
}
