using System;

namespace T03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double currentMoney = double.Parse(Console.ReadLine());
            int totalDays = 0;
            int daysSpent = 0;
            string action;
            double actionAmount;


            while (currentMoney < moneyNeeded)
            {
                action = Console.ReadLine();
                actionAmount = double.Parse(Console.ReadLine());
                totalDays++;
                if (action == "spend")
                {
                    currentMoney -= actionAmount;
                    if (currentMoney < 0)
                    {
                        currentMoney = 0;
                    }
                    daysSpent++;
                    if (daysSpent == 5)
                    {
                        break;
                    }
                }
                else
                {
                    currentMoney += actionAmount;
                    daysSpent = 0;
                }

            }

            if (currentMoney >= moneyNeeded)
            {
                Console.WriteLine($"You saved the money for {totalDays} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(totalDays);
            }
        }
    }
}
