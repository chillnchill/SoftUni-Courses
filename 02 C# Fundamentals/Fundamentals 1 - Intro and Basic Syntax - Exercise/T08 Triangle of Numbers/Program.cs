using System;

namespace T08_Triangle_of_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    Console.Write($"{i} ");
                   
                }
                Console.WriteLine();
            }
        }
    }
}
