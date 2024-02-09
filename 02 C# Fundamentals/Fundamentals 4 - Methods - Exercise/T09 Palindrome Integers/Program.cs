using System;
using System.Linq;

namespace T09_Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            CheckIfInitialNumberIsPalindrome(input);
        }

        private static void CheckIfInitialNumberIsPalindrome(string input)
        {
            while (input != "END")
            {
                char[] inputReverse = input.ToCharArray();
                Array.Reverse(inputReverse);
                string newString = string.Join("", inputReverse);

                if (newString == input)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine(); 
            }
        }
    }
}
