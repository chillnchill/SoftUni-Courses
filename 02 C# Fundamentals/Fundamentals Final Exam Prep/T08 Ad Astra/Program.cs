using System;
using System.Text;
using System.Text.RegularExpressions;

namespace T08_Ad_Astra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string foodPattern = @"([|]{1}|[#]{1})(?<food>[A-Za-z\s]+)\1(?<date>[\d]{2}/[\d]{2}/[\d]{2})\1(?<calories>[\d]+)\1";
            int totalCalories = 0;
            StringBuilder output = new StringBuilder();

            MatchCollection matches = Regex.Matches(input, foodPattern);


            foreach (Match match in matches)
            {
                string food = match.Groups["food"].Value;
                string date = match.Groups["date"].Value;
                int calories = int.Parse(match.Groups["calories"].Value);
                totalCalories += calories;

                output.Append($"Item: {food}, Best before: {date}, Nutrition: {calories}\n");                
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");

            if (matches.Count > 0)
            {
                Console.WriteLine(output);
            }

        }
    }
}
