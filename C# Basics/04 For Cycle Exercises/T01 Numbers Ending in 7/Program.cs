using System;

namespace T01_Numbers_Ending_in_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i <= 997; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
            OR
                for (int i = 7; i <= 997; i+=10)
            {
                Console.WriteLine(i);

            }
;
        }
    }
}
