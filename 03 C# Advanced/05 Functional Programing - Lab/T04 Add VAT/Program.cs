using System;
using System.Linq;

namespace T04_Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> addVat = x => (double.Parse(x) * 1.2).ToString("F2");

            Console.WriteLine(string.Join(Environment.NewLine,
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(addVat)));
                
        }
    }
}
