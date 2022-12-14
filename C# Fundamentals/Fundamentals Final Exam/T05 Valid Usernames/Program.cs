using System;
using System.Linq;

namespace T05_Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ");

            foreach (string line in input)
            {
                if (line.Length >= 3 && line.Length <= 16)
                { 
                    if (line.All(c => Char.IsLetterOrDigit(c) || c.Equals('_') || c.Equals('-')))
                    {
                        Console.WriteLine(line);                        
                    }

                }
            }

            
        }
    }
}
