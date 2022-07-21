using System;

namespace Deposit_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositDeadLine = int.Parse(Console.ReadLine());
            double interestRate = double.Parse(Console.ReadLine());

            double gains = depositSum * (interestRate / 100);
            double aprm = gains / 12;
            double sum = depositSum + depositDeadLine * aprm;

            

            Console.WriteLine(sum);
        }
    }
}
