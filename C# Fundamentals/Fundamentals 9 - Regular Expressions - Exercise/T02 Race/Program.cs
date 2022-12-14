using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace T02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex patternForName = new Regex(@"(?<name>[A-Za-z])");
            string patternForDigits = @"(?<digits>[0-9])";
            int sum = 0;
            var participants = new Dictionary<string, int>();
            List<string> names = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();

            while (input != "end of race")
            {
                MatchCollection matchedNames = patternForName.Matches(input);
                MatchCollection matchedDigits = Regex.Matches(input, patternForDigits);

                string currentName = string.Join("", matchedNames);
                string currentDigits = string.Join("", matchedDigits);

                sum = 0;

                for (int i = 0; i < currentDigits.Length; i++)
                {
                    sum += int.Parse(currentDigits[i].ToString());
                }
                if (names.Contains(currentName))
                {
                    if (!participants.ContainsKey(currentName))
                    {
                        participants.Add(currentName, sum);
                    }
                    else
                    {
                        participants[currentName] += sum;
                    }
                }

                input = Console.ReadLine();
            }
            var winners = participants.OrderByDescending(x => x.Value).Take(3);
            var firstPlace = winners.Take(1);
            var secondPlace = winners.OrderByDescending(x => x.Value).Take(2).OrderBy(x => x.Value).Take(1);
            var thirdPlace = winners.OrderBy(x => x.Value).Take(1);

            foreach (var first in firstPlace)
            {
                Console.WriteLine($"1st place: {first.Key}");
            }
            foreach (var second in secondPlace)
            {
                Console.WriteLine($"2nd place: {second.Key}");
            }
            foreach (var third in thirdPlace)
            {
                Console.WriteLine($"3rd place: {third.Key}");
            }

        }
    }
}
