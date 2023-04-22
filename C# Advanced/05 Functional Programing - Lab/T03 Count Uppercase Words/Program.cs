using System;
using System.Linq;

namespace T03_Count_Uppercase_Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> isUpperCase = ch => char.IsUpper(ch[0]);
            Console.WriteLine(
                String.Join("\n",
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(isUpperCase)
                ));
        }
    }
}
