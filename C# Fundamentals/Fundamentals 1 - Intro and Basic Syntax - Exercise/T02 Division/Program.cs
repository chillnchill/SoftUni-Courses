using System;

namespace T02_Division
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int a = n % 2;
            int b = n % 3;
            int c = n % 6;
            int d = n % 7;
            int e = n % 10;



            if (e == 0)
            {
                Console.WriteLine("The number is divisible by 10");

            }
            else if (d == 0)
            {
                Console.WriteLine("The number is divisible by 7");

            }
            else if (c == 0)
            {
                Console.WriteLine("The number is divisible by 6");

            }
            else if (b == 0)
            {
                Console.WriteLine("The number is divisible by 3");

            }
            else if (a == 0)
            {
                Console.WriteLine("The number is divisible by 2");

            }
            else
            {
                Console.WriteLine("Not divisible");
            }
        }
    }
}
