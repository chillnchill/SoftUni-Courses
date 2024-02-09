using System;
using System.Linq;

namespace T02_Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();

            VowelCounter(input);
        }
        private static void VowelCounter(string text)
        {
            int count = (text.Where(vowel => "aoeui".Contains(vowel))).Count();
            Console.WriteLine(count);
        }
    }
}
