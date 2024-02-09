using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            string emojiPattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitPattern = @"\d";
            BigInteger cool = 1;


            MatchCollection num = Regex.Matches(text, digitPattern);

            foreach (var d in num)
            {
                cool *= int.Parse(d.ToString());
            }
            Console.WriteLine($"Cool threshold: {cool}");

            MatchCollection matches = Regex.Matches(text, emojiPattern);

            Console.WriteLine($"{matches.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matches)
            {
                var emoji = match.Groups["emoji"].Value;
                int coolThreshold = 0;
                for (int i = 0; i < emoji.Length; i++)
                {
                    coolThreshold += emoji[i];
                }
                if (coolThreshold >= cool)
                {
                    Console.WriteLine(match);
                }
            }
           
        }
    }
}
