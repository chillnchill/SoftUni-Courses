using System;

namespace T04_Sum_of_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int sumOfAsciiCode = 0;

            for (int counter = 0; counter < numberOfChars; counter++)
            {
                char givenChar = char.Parse(Console.ReadLine());
                sumOfAsciiCode += (int)givenChar;

            }
            Console.WriteLine($"The sum equals: {sumOfAsciiCode}");
        }
    }
}
