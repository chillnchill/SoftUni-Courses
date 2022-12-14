using System;
using System.Text.RegularExpressions;

namespace Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());            
            string pattern = @"@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            
            for (int i = 0; i < numberOfInputs; i++)
            {
                string productGrp = "";
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);

                if (matches.Count == 0)
                {
                    Console.WriteLine("Invalid barcode");
                    continue;
                }

                foreach (Match match in matches)
                {
                    var product = match.Groups["barcode"].Value;

                    foreach (char c in product)
                    {
                        if (char.IsDigit(c))
                        {
                            productGrp += c;
                        }
                    }
                }
                if (productGrp.Length > 0)
                {
                    Console.WriteLine($"Product group: {productGrp}");
                }
                else
                {
                    Console.WriteLine("Product group: 00");
                }
                
            }



        }
    }
}
