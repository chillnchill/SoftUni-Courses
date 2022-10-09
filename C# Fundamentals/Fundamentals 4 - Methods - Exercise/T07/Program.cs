using System;

namespace T07
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int matrixBase = int.Parse(Console.ReadLine());

            CreatingAMatrix(matrixBase);

        }
        private static void CreatingAMatrix(int matrixBase)
        {
            int counter = 0;

            while (counter < matrixBase)
            {
                counter++;
                for (int i = 0; i < matrixBase; i++)
                {
                    Console.Write($"{matrixBase} ");
                }
                Console.WriteLine();
            }
        }
    }
}
