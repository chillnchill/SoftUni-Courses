using System;

namespace T05_Account_Balance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialInput = Console.ReadLine();
            double sum = 0;


            while (initialInput != "NoMoreMoney")
            {

                double nextInvestment = double.Parse(initialInput);

                if (nextInvestment < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                Console.WriteLine($"Increase: {nextInvestment:f2}");
                sum += nextInvestment;
                initialInput = Console.ReadLine();


            }
            
                Console.WriteLine($"Total: {sum:f2}");
            
        }
    }
}
