using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace T02_Message_Encrypter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfMessages = int.Parse(Console.ReadLine());
            string pattern = @"([*@])(?<tag>[A-Z][a-z]{2,}?)\1\:\s?(?<letters>\[[A-Za-z]]\|\[[A-Za-z]]\|\[[A-Za-z]]\|)$";
            var forDigit = new List<int>();

            for (int i = 0; i < numberOfMessages; i++)
            {
                string input = Console.ReadLine();

                MatchCollection matches = Regex.Matches(input, pattern);

                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {

                        var tag = match.Groups["tag"].Value;
                        var chars = match.Groups["letters"].Value;

                        for (int j = 0; j < chars.Length; j++)
                        {
                            if (char.IsLetter(chars[j]))
                            {
                                forDigit.Add(chars[j]);
                            }
                        }
                        Console.WriteLine($"{tag}: {string.Join(" ", forDigit)}");
                        forDigit.Clear();
                    }
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }

            }
        }
    }
}
