using System;

namespace T02_Sum_Digits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialNumber = int.Parse(Console.ReadLine());
            int sumOfInitialNumber = 0;

            for (int counter = 0; counter < initialNumber; counter++)
            {
                while (initialNumber > 0)
                {
                    int currentNumber = initialNumber % 10;

                    sumOfInitialNumber += currentNumber;

                    initialNumber /= 10;

                }
            }
            Console.WriteLine(sumOfInitialNumber);
        }
    }
}
