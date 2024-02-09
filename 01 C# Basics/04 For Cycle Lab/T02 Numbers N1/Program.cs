using System;

namespace T02_Numbers_N1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int counter = number; counter >= 1; counter--)
            {
                Console.WriteLine(counter);
            }

        }
    }
}
