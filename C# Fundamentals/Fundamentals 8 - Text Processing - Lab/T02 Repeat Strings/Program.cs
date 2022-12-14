using System;

namespace T02_Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            string result = string.Empty;

            foreach (string chunk in input)
            {
                for (int i = 0; i < chunk.Length; i++)
                {
                    result += chunk;
                }
            }

            Console.WriteLine(result);


        }
    }
}
