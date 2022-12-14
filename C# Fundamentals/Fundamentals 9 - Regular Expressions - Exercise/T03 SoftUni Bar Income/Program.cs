using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace T03_SoftUni_Bar_Income
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"%(?<name>[A-Z][a-z]+)%[^|$%.]*<(?<product>[\w]+)[^|$%.]*\|(?<quantity>[\d+])\|[^|$%.]*?(?<price>[\d]+.?[\d]+)?\$";
            string input = Console.ReadLine();
            double sum = 0;
            




            while (input != "end of shift")
            {
                Match matches = Regex.Match(input, pattern);

                if (matches.Success)
                {
                    var name = matches.Groups["name"].Value;
                    var product = matches.Groups["product"].Value;
                    int quantity = int.Parse(matches.Groups["quantity"].Value);
                    double price = double.Parse(matches.Groups["price"].Value);
                    double currentSum = quantity * price;
                    sum += currentSum;

                    Console.WriteLine($"{name}: {product} - {currentSum:f2}");
                }
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {sum:f2}");
        }
    }
}
