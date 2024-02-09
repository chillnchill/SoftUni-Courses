using System;

namespace T09_Greater_of_Two_Values
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string initial = Console.ReadLine();

            if (initial == "int")
            {
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));

            }
            else if (initial == "char")
            {
                char a = char.Parse(Console.ReadLine());
                char b = char.Parse(Console.ReadLine());
                Console.WriteLine(GetMax(a, b));
            }
            else
            {
                string a = Console.ReadLine();
                string b = Console.ReadLine();
                Console.WriteLine(GetMax(a, b));
            }
        }

        private static int GetMax(int a, int b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
        private static char GetMax(char a, char b)
        {
            if (a > b)
            {
                return a;
            }
            return b;
        }
        private static string GetMax(string a, string b)
        {
            int biggerString = a.CompareTo(b);

            if (biggerString > 0)
            {
                return a;
            }
            return b;


        }
    }
}
