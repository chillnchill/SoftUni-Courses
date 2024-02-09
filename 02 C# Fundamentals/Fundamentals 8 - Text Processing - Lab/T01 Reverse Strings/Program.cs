using System;

namespace T01_Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            string newStr = "";

            while (initial != "end")
            {
                for (int i = initial.Length - 1; i >= 0; i--)
                {
                    newStr += initial[i];
                }
                Console.WriteLine($"{initial} = {newStr}");
                newStr = "";
                initial = Console.ReadLine();
            }


        }
    }
}
