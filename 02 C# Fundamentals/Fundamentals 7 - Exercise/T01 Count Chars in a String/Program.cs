using System;
using System.Collections.Generic;

namespace T01_Count_Chars_in_a_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] initial = Console.ReadLine().ToCharArray();
            Dictionary<char, int> charCount = new Dictionary<char, int>();

            foreach (char c in initial)
            {
                if (c != ' ')
                {
                    if (charCount.ContainsKey(c))
                    {
                        charCount[c]++;
                    }
                    else
                    {
                        charCount.Add(c, 1);
                    }
                }

            }

            foreach (var pair in charCount)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
            
        }
    }
}
