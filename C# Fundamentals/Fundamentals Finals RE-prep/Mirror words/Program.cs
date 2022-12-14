using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(@|#)(?<wordOne>[A-Za-z]{3,})\1{2}(?<wordTwo>[A-Za-z]{3,})\1";
            int mirrorWordCount = 0;
            var list = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            foreach (Match match in matches)
            {
                var first = match.Groups["wordOne"].Value;
                var second = match.Groups["wordTwo"].Value;
                string safekeep = second;
                second = string.Join("", second.Reverse());

                if (first == second)
                {
                    mirrorWordCount++;
                    string word = $"{first} <=> {safekeep}";
                    list.Add(word.ToString());

                }
            }
            if (mirrorWordCount > 0)
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(String.Join(", ", list));
            }
            else
            {
                
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
