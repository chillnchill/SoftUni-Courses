using System;
using System.Linq;

namespace T10_Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int lastDigit = 3 % 3;

            Console.WriteLine(lastDigit);
        }
    }
}
