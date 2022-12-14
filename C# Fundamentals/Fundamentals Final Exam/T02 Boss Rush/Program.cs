using System;
using System.Text.RegularExpressions;

namespace T02_Boss_Rush
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfInputs = int.Parse(Console.ReadLine());           
            string pattern = @"\|(?<name>[A-Z]{4,})\|:#(?<title>[A-Za-z]+ [A-Za-z]+)#";
            

            for (int i = 0; i < numOfInputs; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    foreach (Match m in matches)
                    {
                        var name = m.Groups["name"].Value;
                        var title = m.Groups["title"].Value;

                        Console.WriteLine($"{name}, The {title}");
                        Console.WriteLine($">> Strength: {name.Length}");
                        Console.WriteLine($">> Armor: {title.Length}");
                    }
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }

            }
        }
    }
}
