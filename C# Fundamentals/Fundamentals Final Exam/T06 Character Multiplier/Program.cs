using System;

namespace T06_Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
            string longer = "";
            string shorter = "";
            double sum = 0;

            if (input[0].Length > input[1].Length)
            {
                longer = input[0];
                shorter= input[1];
            }
            else 
            {
                longer = input[1];
                shorter = input[0];
            }

            if (longer.Length == shorter.Length)
            {
                for (int i = 0; i < shorter.Length; i++)
                {
                    sum += longer[i] * shorter[i];
                }
            }
            else
            {
                for (int i = 0; i < shorter.Length; i++)
                {
                    sum += longer[i] * shorter[i];
                }
                for (int i = shorter.Length; i < longer.Length; i++)
                {
                    sum += longer[i];
                }
            }
            Console.WriteLine(sum);

        }
    }
}
