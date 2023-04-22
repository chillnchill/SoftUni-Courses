using System;
using System.Linq;

namespace T2._2RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string carNumber = Console.ReadLine();
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int carRow = 0;
            int carCol = 0;
            int carDistanceCovered = 0;
            bool didCarFinish = false;

            for (int row = 0; row < rows; row++)
            {
                char[] field = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = field[col];
                }
            }

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "End")
                {
                    break;
                }

                if (commands == "up")
                {
                    carRow--;
                }
                if (commands == "down")
                {
                    carRow++;
                }
                if (commands == "left")
                {
                    carCol--;
                }
                if (commands == "right")
                {
                    carCol++;
                }

                if (matrix[carRow, carCol] == '.')
                {
                    carDistanceCovered += 10;
                }

                if (matrix[carRow, carCol] == 'T')
                {
                    matrix[carRow, carCol] = '.';

                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row, col] == 'T')
                            {
                                carRow = row;
                                carCol = col;
                            }
                        }     
                    }
                    carDistanceCovered += 30;
                    matrix[carRow, carCol] = '.';
                    continue;

                }

                if (matrix[carRow, carCol] == 'F')
                {
                    carDistanceCovered += 10;
                    matrix[carRow, carCol] = 'C';
                    didCarFinish = true;
                    break;
                }
                //matrix[carRow, carCol] = 'C';
                //Console.WriteLine("=======================================");

            }
            matrix[carRow, carCol] = 'C';
            if (didCarFinish)
            {
                Console.WriteLine($"Racing car {carNumber} finished the stage!");
                Console.WriteLine($"Distance covered {carDistanceCovered} km.");
            }
            else
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
                Console.WriteLine($"Distance covered {carDistanceCovered} km.");
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
