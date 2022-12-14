using System;

namespace pushup_counter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cycle = int.Parse(Console.ReadLine());
            int numberOfcycles = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= cycle; i++)
            {
                sum += i;
            }

            Console.WriteLine(sum * numberOfcycles + 10);
        }
    }
}
