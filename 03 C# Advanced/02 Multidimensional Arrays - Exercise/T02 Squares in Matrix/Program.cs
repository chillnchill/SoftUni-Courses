using System;

namespace T02_Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] initial = Console.ReadLine().Split(' ');
            int rows = int.Parse(initial[0]);
            int cols = int.Parse(initial[1]);
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    string a = matrix[row, col];
                    string b = matrix[row, col + 1];
                    string c = matrix[row + 1, col];
                    string d = matrix[row + 1, col + 1];

                    if (a == b && b == c && c == d)
                    {
                        counter++;
                    }
                }               
            }

            Console.WriteLine(counter);
        }
    }
}
