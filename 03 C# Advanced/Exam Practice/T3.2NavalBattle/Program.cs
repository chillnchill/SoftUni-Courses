using System;
using System.Linq;

namespace T3._2NavalBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int subRow = 0;
            int subCol = 0;
            int mineCounter = 0;
            int cruiserCounter = 0;
            bool isSunk = false;

            for (int row = 0; row < rows; row++)
            {
                string field = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = field[col];

                    if (matrix[row, col] == 'S')
                    {
                        subRow = row;
                        subCol = col;
                    }
                }
            }
            matrix[subRow, subCol] = '-';

            while (true)
            {
                string commands = Console.ReadLine();

                if (commands == "End")
                {
                    break;
                }

                if (commands == "up")
                {
                    subRow--;
                }
                if (commands == "down")
                {
                    subRow++;
                }
                if (commands == "left")
                {
                    subCol--;
                }
                if (commands == "right")
                {
                    subCol++;
                }

                if (matrix[subRow, subCol] == '*')
                {
                    matrix[subRow, subCol] = '-';
                    mineCounter++;
                    if (mineCounter == 3)
                    {
                        isSunk = true;
                        break;
                    }
                }
                if (matrix[subRow, subCol] == 'C')
                {
                    matrix[subRow, subCol] = '-';
                    cruiserCounter++;
                    if (cruiserCounter == 3)
                    {
                        break;
                    }
                }
                

            }
            matrix[subRow, subCol] = 'S';
            if (isSunk)
            {
                Console.WriteLine($"Mission failed, U-9 disappeared! Last known coordinates [{subRow}, {subCol}]!");
            }
            else
            {
                Console.WriteLine("Mission accomplished, U-9 has destroyed all battle cruisers of the enemy!");
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
