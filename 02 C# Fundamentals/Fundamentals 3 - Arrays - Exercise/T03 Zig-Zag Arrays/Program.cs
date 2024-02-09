using System;
using System.Linq;

namespace T03_Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfArrays = int.Parse(Console.ReadLine());
            int[] arraysEven = new int[numOfArrays];
            int[] arraysOdd = new int[numOfArrays];


            for (int i = 0; i < numOfArrays; i++)
            {

                int[] numbers = Console.ReadLine()
               .Split(' ')
               .Select(int.Parse)
               .ToArray();

                if (i % 2 == 0)
                {
                    arraysEven[i] = numbers[0];
                    arraysOdd[i] = numbers[1];
                }
                else
                {
                    arraysEven[i] = numbers[1];
                    arraysOdd[i] = numbers[0];
                }

            }

            Console.WriteLine(String.Join(" ", arraysEven));
            Console.WriteLine(String.Join(" ", arraysOdd));

        }
    }
}
