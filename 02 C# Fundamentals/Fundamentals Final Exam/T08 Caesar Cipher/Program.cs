using System;

namespace T08_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string output = "";

            
            for (int i = 0; i < input.Length; i++)
            {
                char ch = (char)(input[i] + 3);
                output += ch;
            }
            Console.WriteLine(output);
        }
    }
}
