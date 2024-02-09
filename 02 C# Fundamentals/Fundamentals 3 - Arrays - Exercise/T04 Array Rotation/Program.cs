using System;
using System.Linq;

namespace T04_Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
            int rotation = int.Parse(Console.ReadLine());
            int lastDigit = 0;
            
            for (int i = 0; i < rotation; i++)
            {
                lastDigit = numbers[0];

                for (int operations = 0; operations < numbers.Length - 1; operations++)
                {
                    
                    numbers[operations] = numbers[operations + 1];
                }
                numbers[numbers.Length - 1] = lastDigit;
            }
            
        }
    }
}
