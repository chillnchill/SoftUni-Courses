using System;

namespace T00_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = 0;

            for (int i = 1; i <= 6; i++)
            {
                start += i;
                Console.WriteLine(start);
            }
            
        }

    }
}
