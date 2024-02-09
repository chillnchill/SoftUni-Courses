using System;
using System.Linq;

namespace T06_Replace_Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            

            for (int i = 1; i < initial.Length; i++)
            {
                char currChar = initial[i];
                char prevChar = initial[i - 1];

                if (prevChar != currChar)
                {
                    Console.Write(prevChar);
                }
                if (i == initial.Length - 1)
                {
                    Console.WriteLine(currChar);
                }
            }

            

        }




    }
}

