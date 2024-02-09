using System;

namespace T02_Equal_Sums_Even_Odd_Position
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());


            for (int i = firstNumber; i <= secondNumber; i++)
            {
                string currentNum = i.ToString();
                int odd = 0;
                int even = 0;

                for (int j = 0; j < currentNum.Length; j++)
                {
                    int currentDigit = int.Parse(currentNum[j].ToString());
                    if (j % 2 == 0)
                    {
                        even += currentDigit;
                    }
                    else
                    {
                        odd += currentDigit;
                    }
                }
                if (odd == even)
                {
                    Console.Write(currentNum + " ");
                }
            }
        }
    }
}
