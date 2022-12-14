using System;

namespace T11_Letters_Change_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;

            foreach (string line in input)
            {
                char firstLetter = line[0];
                char secondLetter = line[^1];
                double number = double.Parse(line[1..^1]);
                int firstNum = 0;
                int secondNum = 0;

                if (char.IsUpper(firstLetter))
                {
                    firstNum = firstLetter - 64;
                    number /= firstNum;
                }
                else
                {
                    firstNum = firstLetter - 96;
                    number *= firstNum;
                }

                if (char.IsLower(secondLetter))
                {
                    secondNum = secondLetter - 96;
                    number += secondNum;
                }
                else
                {
                    secondNum = secondLetter - 64;
                    number -= secondNum;
                }
                sum += number;
            }
            Console.WriteLine($"{sum:f2}");

        }
    }
}
