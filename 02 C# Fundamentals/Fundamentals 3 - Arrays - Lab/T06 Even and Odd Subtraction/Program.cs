using System;

namespace T06_Even_and_Odd_Subtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialValues = Console.ReadLine();
            string[] items = initialValues.Split();
            int[] toMath = new int[items.Length];
            int sumOfEvenNumbers = 0;
            int sumOfOddNumbers = 0;

            for (int i = 0; i < items.Length; i++)
            {
                toMath[i] = int.Parse(items[i]);
                
                if (toMath[i] % 2 == 0)
                {
                    sumOfEvenNumbers += toMath[i];
                }
                else
                {
                    sumOfOddNumbers += toMath[i];
                }
            }

                Console.WriteLine(sumOfEvenNumbers - sumOfOddNumbers);
 
        }
    }
}
