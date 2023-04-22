using System;

namespace T04_Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int initial = int.Parse(Console.ReadLine());
            int rows = initial;
            int cols = initial;
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                int counter = 0;

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[counter];
                    counter++;
                }
            }

            char soughtSymbol = char.Parse(Console.ReadLine());

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    char current = matrix[row, col];
                    if (current == soughtSymbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }

            Console.WriteLine($"{soughtSymbol} does not occur in the matrix");

        }
    }
}
