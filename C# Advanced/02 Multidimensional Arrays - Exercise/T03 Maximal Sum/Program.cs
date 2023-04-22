using System;

namespace T03_Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initial = Console.ReadLine().Split(' ');
            int rows = int.Parse(initial[0]);
            int cols = int.Parse(initial[1]);
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(input[col]);
                }
            }

            int startRow = 0;
            int startCol = 0;
            int squareSum = 0;
            int biggest = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    squareSum += matrix[row, col];
                    squareSum += matrix[row, col + 1];
                    squareSum += matrix[row, col + 2];
                    squareSum += matrix[row + 1, col];
                    squareSum += matrix[row + 1, col + 1];
                    squareSum += matrix[row + 1, col + 2];
                    squareSum += matrix[row + 2, col];
                    squareSum += matrix[row + 2, col + 1];
                    squareSum += matrix[row + 2, col + 2];

                    if (squareSum > biggest)
                    {
                        biggest = squareSum;
                        startRow = row;
                        startCol = col;
                    }
                    squareSum = 0;
                }
            }
            Console.WriteLine($"Sum = {biggest}");

            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
