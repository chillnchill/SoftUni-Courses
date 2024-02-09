using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T05_Nether_Realms
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            string patternHP = @"[^\+\-\*\/\.,0-9]";
            string patternDMG = @"-?\d+\.?\d*";
            string patternMultipleDivide = @"[\*\/]";
            string patternNextDemon = @"[,\s]+";
            string input = Console.ReadLine();
            string[] demonName = Regex.Split(input, patternNextDemon).OrderBy(x => x).ToArray();


            for (int i = 0; i < demonName.Length; i++)
            {
                var currentDemon = demonName[i];
                var hp = 0;
                double dmg = 0;

                var matchesHP = Regex.Matches(currentDemon, patternHP, RegexOptions.IgnoreCase);

                foreach (Match match in matchesHP)
                {
                    char curChar = char.Parse(match.ToString());
                    hp += curChar;
                }

                var currentDamage = Regex.Matches(currentDemon, patternDMG, RegexOptions.IgnoreCase);

                foreach (Match match in currentDamage)
                {
                    double deeps = double.Parse(match.ToString());
                    dmg += deeps;
                }

                var additionalActions = Regex.Matches(currentDemon, patternMultipleDivide, RegexOptions.IgnoreCase);

                foreach (Match match in additionalActions)
                {
                    char currSymbol = char.Parse(match.ToString());
                    if (currSymbol == '*')
                    {
                        dmg *= 2;
                    }
                    else
                    {
                        dmg /= 2;
                    }
                }

                Console.WriteLine($"{currentDemon} - {hp} health, {dmg:f2} damage");

            }


        }
    }
}
