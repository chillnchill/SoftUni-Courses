using System;

namespace T02.HelloSoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string numberOfCatFood = Console.ReadLine();


            double dogFood = 2.50;
            int catFood = 4;

            int totalPrice = (int)( catFood * dogFood);

            Console.WriteLine($"{totalPrice} lv.");

        }
    }
}
