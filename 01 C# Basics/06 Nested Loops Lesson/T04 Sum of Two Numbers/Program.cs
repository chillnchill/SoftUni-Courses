using System;

namespace T04_Sum_of_Two_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());

            int correctNumber = 0;
            bool hasMagicNumberBeenFound = false;

            for (int i = firstNumber; i <= secondNumber; i++)
            {
                for (int j = firstNumber; j <= secondNumber; j++)
                {
                    correctNumber++;
                    if (i + j == magicNumber)
                    {
                        hasMagicNumberBeenFound = true;
                        Console.WriteLine($"Combination N:{correctNumber} ({i} + {j} = {magicNumber})");
                        break;
                    }
                }
                if (hasMagicNumberBeenFound)
                {
                    break;
                }
            }
            if (!hasMagicNumberBeenFound)
            {
                Console.WriteLine($"{correctNumber} combinations - neither equals {magicNumber}");
            }
        }
    }
}
