using System;

namespace T01_Number_Pyramid
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initialNumber = int.Parse(Console.ReadLine());
            int currentNum = 1;

            for (int lines = 1; lines <= initialNumber; lines++)
            {
                for (int numbersOnALine = 1; numbersOnALine <= lines; numbersOnALine++)
                {
                    Console.Write($"{currentNum} ");
                    currentNum++;
                    if (currentNum > initialNumber)
                    {
                        break;
                    }
                }
                if (currentNum > initialNumber)
                {
                    break;
                }
                Console.WriteLine();
            }
        }
    }
}
