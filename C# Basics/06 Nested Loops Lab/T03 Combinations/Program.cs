using System;

namespace T03_Combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magicNumber = int.Parse(Console.ReadLine());
            int combinations = 0;

            for (int i = 0; i <= magicNumber; i++)
            {
                for (int j = 0; j <= magicNumber; j++)
                {
                    for (int k = 0; k <= magicNumber; k++)
                    {

                        if (i + j + k == magicNumber)
                        {
                            combinations++;
                        }
                    }
                }
            }
            Console.WriteLine(combinations);
        }
    }
}
