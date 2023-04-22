using System;
using System.Linq;

namespace T05_Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] builder = Console.ReadLine().Split(' ');
            int rows = int.Parse(builder[0]);
            int cols = int.Parse(builder[1]);
            string[,] matrix = new string[rows, cols];
            string input = Console.ReadLine();

            int counter = 1;
            int currentIndex = 0;

            for (int row = 0; row < rows; row++)
            {
                if (counter % 2 != 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = input[currentIndex].ToString();
                        currentIndex++;
                        if (currentIndex == input.Length)
                        {
                            currentIndex = 0;
                        }
                    }
                   
                }
                else
                {                    
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = input[currentIndex].ToString();
                        currentIndex++;
                        if (currentIndex == input.Length)
                        {
                            currentIndex = 0;
                        }
                    }                  
                }
                counter++;
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
