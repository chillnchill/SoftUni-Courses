using System;

namespace T03_Characters_in_Range
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char charOne = char.Parse(Console.ReadLine());
            char charTwo = char.Parse(Console.ReadLine());

            GetCharsInBetween(charOne, charTwo);
        }
        private static void GetCharsInBetween(char charOne, char charTwo)
        {
            int startChar = Math.Min(charOne, charTwo);
            int endChar = Math.Max(charOne, charTwo);

            for (int i = startChar + 1; i < endChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }

}