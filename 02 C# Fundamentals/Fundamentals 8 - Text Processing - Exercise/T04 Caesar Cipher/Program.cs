using System;
using System.Linq;
using System.Text;

namespace T04_Caesar_Cipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < initial.Length; i++)
            {
                char ch = (char)(initial[i] + 3);
                stringBuilder.Append(ch);
            }
            Console.WriteLine(stringBuilder);
        }
    }
}
