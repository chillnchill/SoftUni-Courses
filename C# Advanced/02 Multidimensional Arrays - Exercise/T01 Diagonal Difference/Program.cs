using System;
using System.Linq;

namespace T01_Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            int[,] matrix = new int[rows,cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int sumDiagonalLeft = 0;
            int sumDiagonalRight = 0;

            for (int row = 0; row < rows; row++)
            {
                sumDiagonalLeft += matrix[row, row];
            }
            int counter = 0;

            for (int col = cols-1; col >= 0; col--)
            {
                sumDiagonalRight += matrix[counter, col];
                counter++;
            }

            int difference = 0;
            
            if (sumDiagonalLeft >= sumDiagonalRight)
            {
                difference = sumDiagonalLeft - sumDiagonalRight;
            }
            else
            {
                difference = sumDiagonalRight - sumDiagonalLeft;
            }

            Console.WriteLine(difference);

        }
    }
}
