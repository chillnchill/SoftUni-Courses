using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T04_Mirror_words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string pattern = @"([@]|[#])(?<group>[A-Za-z]{3,})\1{2}(?<reverse>[A-Za-z]{3,})\1";
            int pairs = 0;
            var validPairs = new List<string>();
            MatchCollection matches = Regex.Matches(text, pattern);


            foreach (Match match in matches)
            {
                string group = match.Groups["group"].Value;
                string reverse = match.Groups["reverse"].Value;
                string reversed = string.Join("", reverse.Reverse());
                pairs++;

                if (group == reversed)
                {
                    string success = $"{group} <=> {reverse}";
                    validPairs.Add(success);
                }
            }


            if (validPairs.Count > 0 && pairs > 0)
            {
                Console.WriteLine($"{pairs} word pairs found!");
                Console.WriteLine("The mirror words are:");
                Console.Write(String.Join(", ", validPairs));

            }
            else if (pairs != 0 && validPairs.Count == 0)
            {
                Console.WriteLine($"{pairs} word pairs found!");

                Console.WriteLine("No mirror words!");
            }
            else if (validPairs.Count == 0 && validPairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }

        }
    }
}
