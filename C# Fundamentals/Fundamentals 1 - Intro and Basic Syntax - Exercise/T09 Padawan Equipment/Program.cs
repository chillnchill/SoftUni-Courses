using System;

namespace T09_Padawan_Equipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double startingMoney = double.Parse(Console.ReadLine());
            int numberOfStudents = int.Parse(Console.ReadLine());
            double singleSaberPrice = double.Parse(Console.ReadLine());
            double singleRobePrice = double.Parse(Console.ReadLine());
            double singleBeltPrice = double.Parse(Console.ReadLine());

            // total sabre cost
            double totalSabers = Math.Ceiling(numberOfStudents * 1.10);
            double SabersPrice = singleSaberPrice * totalSabers;
            //total robe cost
            double robePrice = numberOfStudents * singleRobePrice;
            //total belt cost
            double freeBelts = Math.Floor(numberOfStudents / 6.0);
            double beltPrice = (numberOfStudents - freeBelts) * singleBeltPrice;

            //final cost
            double total = SabersPrice + robePrice + beltPrice;

            if (total <= startingMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {total:f2}lv.");
            }
            else
            {
                Console.WriteLine($"John will need {total - startingMoney:f2}lv more.");
            }

        }
    }
}
