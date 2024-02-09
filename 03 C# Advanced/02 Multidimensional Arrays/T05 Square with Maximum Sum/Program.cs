using System;

namespace T05_Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initial = Console.ReadLine().Split(", ");
            int rows = int.Parse(initial[0]);
            int cols = int.Parse(initial[1]);
            int subMatrixRols = 2;
            int subMatrixCols = 2;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine().Split(", ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(values[col]);
                }
            }

            int squareSum = 0;
            int currentBiggest = 0;
            int squareStartRow = 0;
            int squareStartCol = 0;

            for (int row = 0; row < rows - subMatrixRols+1; row++)
            {
                for (int col = 0; col < cols - subMatrixCols+1; col++)
                {
                    squareSum += matrix[row, col];
                    squareSum += matrix[row, col + 1];
                    squareSum += matrix[row + 1, col];
                    squareSum += matrix[row + 1, col + 1];
                    if (squareSum > currentBiggest)
                    {
                        currentBiggest = squareSum;
                        squareStartRow = row;
                        squareStartCol = col;
                    }
                    squareSum = 0;
                }
            }
            
            Console.WriteLine($"{matrix[squareStartRow, squareStartCol]} {matrix[squareStartRow, squareStartCol+1]}");
            Console.WriteLine($"{matrix[squareStartRow+1, squareStartCol]} {matrix[squareStartRow+1, squareStartCol+1]}");
            Console.WriteLine(currentBiggest);
        }
    }
}
