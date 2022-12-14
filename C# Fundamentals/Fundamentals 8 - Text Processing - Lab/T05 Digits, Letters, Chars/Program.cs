using System;
using System.Linq;
using System.Text;

namespace T05_Digits__Letters__Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            //StringBuilder digits = new StringBuilder();
            //StringBuilder letters = new StringBuilder();
            //StringBuilder others = new StringBuilder();

            //foreach (char c in input)
            //{
            //    if (char.IsDigit(c))
            //    {
            //        digits.Append(c);
            //    }
            //    else if (char.IsLetter(c))
            //    {
            //        letters.Append(c);
            //    }
            //    else
            //    {
            //        others.Append(c);
            //    }
            //}

            //Console.WriteLine(digits);
            //Console.WriteLine(letters);
            //Console.WriteLine(others);


            //the entirety of the above code can be shorened to 4 lines using LINQ:

            Console.WriteLine(input.Where(ch => char.IsDigit(ch)).ToArray());
            Console.WriteLine(input.Where(ch => char.IsLetter(ch)).ToArray());
            Console.WriteLine(input.Where(ch => !char.IsLetterOrDigit(ch)).ToArray());
        }
    }
}
