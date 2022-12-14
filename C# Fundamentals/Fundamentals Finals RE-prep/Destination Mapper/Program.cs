using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=|\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            var destiList = new List<string>();
            int travelPoints = 0;

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                var destionation = match.Groups["destination"].Value;
                destiList.Add(destionation);
                travelPoints += destionation.Length;
            }

            Console.WriteLine($"Destinations: {string.Join(", ", (destiList))}");
            Console.WriteLine($"Travel Points: {travelPoints}");    
        }
    }
}
