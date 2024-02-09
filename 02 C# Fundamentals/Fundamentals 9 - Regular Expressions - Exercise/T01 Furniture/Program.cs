using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T01_Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @">>(?<name>[A-Z][a-z]+|[A-Z]+)<<(?<price>[0-9]+|[0-9]+.[0-9]+)!(?<quantity>\d+)";
            var list = new List<string>();
            double totalPrice = 0;

            while (input != "Purchase")
            {
                Match matches = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                

                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    var price = double.Parse(matches.Groups["price"].Value);
                    var quantity = int.Parse(matches.Groups["quantity"].Value);
                    list.Add(name);
                    totalPrice += price * quantity;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"{totalPrice:f2}");

        }
    }
}
