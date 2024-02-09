using System;
using System.Linq;

namespace T02_Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int startRow = 0;
            int startCol = 0;
            int holeCount = 1;
            int rodsHit = 0;

            for (int row = 0; row < rows; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                    if (matrix[row, col] == 'V')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            matrix[startRow, startCol] = '*';

            int oldStartRow = startRow;
            int oldStartCol = startCol;

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "End")
                {
                    break;
                }

                switch (commands)
                {
                    case "up":
                        startRow--;
                        break;
                    case "down":
                        startRow++;
                        break;
                    case "left":
                        startCol--;
                        break;
                    case "right":
                        startCol++;
                        break;
                }
                if (startRow >= 0 && startRow < rows && startCol >= 0 && startCol < cols)
                {
                    if (matrix[startRow, startCol] == '-')
                    {
                        matrix[startRow, startCol] = '*';
                        holeCount++;
                        oldStartRow = startRow;
                        oldStartCol = startCol;
                    }
                    else if (matrix[startRow, startCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{startRow}, {startCol}]!");

                    }
                    else if (matrix[startRow, startCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodsHit++;
                        startRow = oldStartRow;
                        startCol = oldStartCol;
                    }
                    else if (matrix[startRow, startCol] == 'C')
                    {
                        holeCount++;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holeCount} hole(s).");
                        matrix[startRow, startCol] = 'E';

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write($"{matrix[row, col]}");
                            }
                            Console.WriteLine();
                        }
                        return;
                    }
                }
                else
                {
                    startCol = oldStartCol;
                    startRow = oldStartRow;
                }
            }

            Console.WriteLine($"Vanko managed to make {holeCount} hole(s) and he hit only {rodsHit} rod(s).");
            matrix[startRow, startCol] = 'V';
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
