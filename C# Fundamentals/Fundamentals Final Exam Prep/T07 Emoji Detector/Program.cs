using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace T07_Emoji_Detector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            string patternEmoji = @"([*]{2}|[:]{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string patternThresh = @"[0-9]";
            BigInteger cool = 1;
            int emojiSum = 0;

            MatchCollection matchedNums = Regex.Matches(initial, patternThresh);

            foreach (Match match in matchedNums)
            {
                int currentDigit = int.Parse(match.ToString());
                cool *= currentDigit;
                if (currentDigit == 0)
                {
                    cool = 0;
                    break;
                }
            }

            Console.WriteLine($"Cool threshold: {cool}");

            MatchCollection matchedEmoji = Regex.Matches(initial, patternEmoji);

            Console.WriteLine($"{matchedEmoji.Count} emojis found in the text. The cool ones are:");

            foreach (Match match in matchedEmoji)
            {
                
                string currentMatch = match.Groups["emoji"].Value;

                for (int i = 0; i < currentMatch.Length; i++)
                {
                    int currentSum = currentMatch[i];
                    emojiSum += currentSum;

                }
                if (emojiSum >= cool)
                {
                    Console.WriteLine(match);
                }
                emojiSum = 0;
            }

        }
    }
}
