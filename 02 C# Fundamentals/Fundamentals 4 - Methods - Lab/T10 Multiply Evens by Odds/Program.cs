using System;
using System.Linq;

namespace T10_Multiply_Evens_by_Odds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            number = Math.Abs(number);

            int sumEven = GetSumOfEvenDigits(number) * 2;
            int sumOdd = GetSumOfOddDigits(number);
            GetMultipleOfEvenAndOdds(sumEven, sumOdd);

        }


        static int GetSumOfEvenDigits(int number)
        {
            string toString = number.ToString();
            int sumEven = 0;

            for (int i = 0; i < toString.Length; i++)
            {
                int breakDown = number % 10;
                if (breakDown % 2 == 0)
                {
                    sumEven += breakDown;
                }
                number = number / 10;
            }
            return sumEven;

        }
        static int GetSumOfOddDigits(int number)
        {

            string toString = number.ToString();
            int sumOdd = 0;
            for (int i = 0; i < toString.Length; i++)
            {
                int breakDown = number % 10;

                if (breakDown % 2 != 0)
                {
                    sumOdd += breakDown;
                }
                number = number / 10;
            }
            return sumOdd;
            
        }
        private static void GetMultipleOfEvenAndOdds(int sumEven, int sumOdd)
        {
            Console.WriteLine(sumEven * sumOdd);
        }

    }
}
