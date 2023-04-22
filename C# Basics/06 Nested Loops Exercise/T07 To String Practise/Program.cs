using System;

namespace T07_To_String_Practise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string str = n.ToString();
            for (int i = 0; i < str.Length; i++)
            {
                Console.WriteLine($"{str[i]}");
            }
        }
    }
}
