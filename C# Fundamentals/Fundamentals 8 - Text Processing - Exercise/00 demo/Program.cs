using System;

namespace _00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            double sum = 0;    

            foreach (string chunk in input)
            {
                char firstChar = chunk[0];
                char secondChar = chunk[^1];
                string middle = chunk[1..^1];
                double number = double.Parse(middle);

                //for the first char in the string
                if (char.IsUpper(firstChar))
                {
                    int positionOfLetter = firstChar - 64;
                    number /= positionOfLetter;
                }
                else
                {
                    int positionOfLetter = firstChar - 96;
                    number *= positionOfLetter;
                }

                //for the second char in the string
                if (char.IsUpper(secondChar))
                {
                    int positionOfLetter = secondChar - 64;
                    number -= positionOfLetter;
                }
                else
                {
                    int positionOfLetter = secondChar - 96;
                    number += positionOfLetter;
                }

                sum += number;
                
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
