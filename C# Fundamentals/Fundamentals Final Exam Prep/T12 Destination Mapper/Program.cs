using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T12_Destination_Mapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([=\/])(?<destination>[A-Z][A-Za-z]{2,})\1";
            int travelPoints = 0;
            var places = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                string destination = match.Groups["destination"].Value;
                places.Add(destination);
                travelPoints += destination.Length;

            }

            Console.WriteLine($"Destinations: {string.Join(", ", places)}");
            Console.WriteLine($"Travel Points: {travelPoints}");


        }
    }
}
