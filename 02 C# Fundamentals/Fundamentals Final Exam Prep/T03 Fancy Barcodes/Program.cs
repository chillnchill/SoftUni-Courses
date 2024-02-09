using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace T03_Fancy_Barcodes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCodes = int.Parse(Console.ReadLine());            
            string pattern = @"@#+(?<item>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";


            for (int i = 0; i < numberOfCodes; i++)
            {
                string barcodes = Console.ReadLine();
                Match matches = Regex.Match(barcodes, pattern);


                if (matches.Success)
                {
                    var item = matches.Groups["item"].Value;
                    char[] digits = item.Where(char.IsDigit).ToArray();

                    string barcodeGroup = digits.Length == 0 ? "00" : string.Join("", digits);
                    
                        Console.WriteLine($"Product group: {barcodeGroup}");
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
