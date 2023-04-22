using System;

namespace Greater_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());

            int b = int.Parse(Console.ReadLine());
            bool isBiggerNumber = a > b;

            if (isBiggerNumber)
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
