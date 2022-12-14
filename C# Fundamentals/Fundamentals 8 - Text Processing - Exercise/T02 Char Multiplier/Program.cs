using System;

namespace T02_Char_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            MultiplyingCharEquivalents(input[0], input[1]);
            
        }

        private static void MultiplyingCharEquivalents(string one, string two)
        {
            string longer = "";
            string shorter = "";

            if (one.Length > two.Length)
            {
                longer = one;
                shorter = two;
            }
            else
            {
                longer = two;
                shorter = one;
            }

            int result = 0;

            for (int i = 0; i < shorter.Length; i++)
            {
                result += shorter[i] * longer[i];
            }
            for (int i = shorter.Length; i < longer.Length; i++)
            {
                result += longer[i];
            }


            Console.WriteLine(result);
        }
    }
}
