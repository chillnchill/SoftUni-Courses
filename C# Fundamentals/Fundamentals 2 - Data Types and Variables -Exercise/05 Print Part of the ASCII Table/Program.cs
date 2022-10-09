using System;

namespace _05_Print_Part_of_the_ASCII_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int digitOfFirstChar = int.Parse(Console.ReadLine());
            int digitOfSecondChar = int.Parse(Console.ReadLine());

            for (int counter = digitOfFirstChar; counter <= digitOfSecondChar; counter++)
            {
                Console.Write($"{(char)counter} ");  
            }




        }
    }
}
