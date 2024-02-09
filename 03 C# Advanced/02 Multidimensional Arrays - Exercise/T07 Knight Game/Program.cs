using System;

namespace _07.KnightGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);

                return;
            }

            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string chars = Console.ReadLine();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int mostAttackingKnight = 0;
                int mostAttackingRow = 0;
                int mostAttackingCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (matrix[row, col] == 'K')
                        {
                            int currentAttackedKnights = CountAttacked(row, col, size, matrix);

                            if (mostAttackingKnight < currentAttackedKnights)
                            {
                                mostAttackingKnight = currentAttackedKnights;
                                mostAttackingRow = row;
                                mostAttackingCol = col;
                            }
                        }
                    }
                }
                if (mostAttackingKnight == 0)
                {
                    break;
                }
                else
                {
                    matrix[mostAttackingRow, mostAttackingCol] = '0';
                    knightsRemoved++;
                }
            }
            Console.WriteLine(knightsRemoved);
        }

        static int CountAttacked(int row, int col, int size, char[,] matrix)
        {
            int currentAttackedKnights = 0;

            if (IsCellValid(row + 2, col + 1, size))
            {
                if (matrix[row + 2, col + 1] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row + 2, col - 1, size))
            {
                if (matrix[row + 2, col - 1] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row + 1, col + 2, size))
            {
                if (matrix[row + 1, col + 2] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row + 1, col - 2, size))
            {
                if (matrix[row + 1, col - 2] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row - 2, col - 1, size))
            {
                if (matrix[row - 2, col - 1] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row - 2, col + 1, size))
            {
                if (matrix[row -2, col + 1] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row - 1, col + 2, size))
            {
                if (matrix[row - 1, col + 2] == 'K')
                {
                    currentAttackedKnights++;
                }
            }

            if (IsCellValid(row - 1, col - 2, size))
            {
                if (matrix[row - 1, col - 2] == 'K')
                {
                    currentAttackedKnights++;
                }
            }
            return currentAttackedKnights;
        }

        static bool IsCellValid(int row, int col, int size)
        {
            return row >= 0 && col >= 0 && row < size && col < size;
        }
    }
}