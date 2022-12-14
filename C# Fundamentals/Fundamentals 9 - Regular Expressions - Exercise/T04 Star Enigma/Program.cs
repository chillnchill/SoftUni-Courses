using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace _01._Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string codeCrackPattern = @"[S,T,A,R,s,t,a,r]";
            int commands = int.Parse(Console.ReadLine());
            string crackedCode = "";
            string commandPattern = @"@(?<planet>[A-z]+)[^@\-!:>]*:(?<population>[\d]+)[^@\-!:>]*!(?<action>[A,D])![^@\-!:>]*->(?<soldiers>[\d]+)";
            var logA = new List<string>();
            var logD = new List<string>();

            for (int i = 0; i < commands; i++)
            {
                string input = Console.ReadLine();
                Regex regex = new Regex(codeCrackPattern);
                MatchCollection matches = regex.Matches(input);
                int codeKey = matches.Count;

                for (int j = 0; j < input.Length; j++)
                {
                    char ch = (char)(input[j] - codeKey);
                    crackedCode += ch;
                }

                
                Match commandsMatches = Regex.Match(crackedCode, commandPattern);

                
                if (commandsMatches.Success)
                {
                    var planet = commandsMatches.Groups["planet"].Value;
                    var action = commandsMatches.Groups["action"].Value;

                    if (action == "A")
                    {
                        logA.Add(planet);
                    }
                    else
                    {
                        logD.Add(planet);
                    }                   
                }
                
                crackedCode = "";
                
            }
            
            logA.Sort();
            logD.Sort();
            Console.WriteLine($"Attacked planets: {logA.Count}");
            logA.ForEach(x => Console.WriteLine($"-> {x}"));
            Console.WriteLine($"Destroyed planets: {logD.Count}");
            logD.ForEach(x => Console.WriteLine($"-> {x}"));

        }
    }
}