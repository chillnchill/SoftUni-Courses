using System;

namespace T03_Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows, cols];
            int diagonalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                string[] rowData = Console.ReadLine().Split(" ");

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = int.Parse(rowData[col]);
                }
            }

            for (int col = 0; col < cols; col++)
            {          
                for (int row = 0; row < rows; row++)
                {
                    diagonalSum += matrix[row, col];
                    col++;  
                }
                break;
            }

            Console.WriteLine(diagonalSum);
        }
    }
}
