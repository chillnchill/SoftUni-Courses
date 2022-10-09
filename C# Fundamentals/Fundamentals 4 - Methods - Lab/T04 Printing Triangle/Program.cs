using System;

namespace T04_Printing_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                BuildingATriangle(1, i);
            }
            for (int i = n-1; i > 0; i--)
            {
                BuildingATriangle(1, i);
            }
        }

        private static void BuildingATriangle(int start, int end)
        {
            
            for (int i = start; i <= end; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();

        }
    }
}
