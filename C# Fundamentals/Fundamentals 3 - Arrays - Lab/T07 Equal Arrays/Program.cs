using System;
using System.Linq;

namespace T07_Equal_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arrayOne = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            int[] arrayTwo = Console.ReadLine()
            .Split(' ')
            .Select(int.Parse)
            .ToArray();

            int sumOne = 0;

            for (int index = 0; index < arrayOne.Length; index++)
            {
                if (arrayOne[index] != arrayTwo[index])
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {index} index");
                    break;
                }
                else
                {
                    sumOne += arrayOne[index];
                }
                if (index == arrayOne.Length - 1)
                {
                    Console.WriteLine($"Arrays are identical. Sum: {sumOne}");
                }
                    
            }

           








        }
    }
}
