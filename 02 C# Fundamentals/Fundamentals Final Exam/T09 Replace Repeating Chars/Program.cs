using System;

namespace T09_Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char check = input[0];

            for (int i = 1; i < input.Length; i++)
            {
                if (check == input[i])
                {
                    input = input.Remove(i, 1);
                    i--;
                }
                else
                {
                    check = input[i];
                }
            }
            Console.WriteLine(input);
        }
    }
}
