using System;

namespace T04_Even_Powers_of_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double num = 1;

            for (int counter = 0; counter <= n; counter+=2)
            {
                Console.WriteLine(num);
                num *= 4;
            }

        }
    }
}
