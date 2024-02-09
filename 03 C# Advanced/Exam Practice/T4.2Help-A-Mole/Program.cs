using System;

namespace T4._2Help_A_Mole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int moleRow = 0;
            int moleCol = 0;
            int points = 0;


            for (int row = 0; row < rows; row++)
            {
                string field = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = field[col];

                    if (matrix[row, col] == 'M')
                    {
                        moleRow = row;
                        moleCol = col;
                    }
                }
            }
            matrix[moleRow, moleCol] = '-';

            while (true)
            {
                string commands = Console.ReadLine();
                bool didMoleChangePosition = false;

                if (commands == "End")
                {
                    break;
                }
                if (points >= 25)
                {
                    break;
                }

                if (commands == "up")
                {
                    if (IsPositionInField(matrix, moleRow - 1, moleCol, rows, cols))
                    {
                        moleRow--;
                        didMoleChangePosition = true;
                    }
                }
                if (commands == "down")
                {
                    if (IsPositionInField(matrix, moleRow + 1, moleCol, rows, cols))
                    {
                        moleRow++;
                        didMoleChangePosition = true;
                    }
                }
                if (commands == "left")
                {
                    if (IsPositionInField(matrix, moleRow, moleCol - 1, rows, cols))
                    {
                        moleCol--;
                        didMoleChangePosition = true;
                    }
                }
                if (commands == "right")
                {
                    if (IsPositionInField(matrix, moleRow, moleCol + 1, rows, cols))
                    {
                        moleCol++;
                        didMoleChangePosition = true;
                    }
                }

                if (!didMoleChangePosition)
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    continue;
                }

                if (matrix[moleRow, moleCol] == 'S')
                {
                    matrix[moleRow, moleCol] = '-';
                    points -= 3;
                    for (int row = 0; row < rows; row++)
                    {
                        for (int col = 0; col < cols; col++)
                        {
                            if (matrix[row, col] == 'S')
                            {
                                moleRow = row;
                                moleCol = col;
                            }
                        }
                    }
                }

                if (char.IsDigit(matrix[moleRow, moleCol]))
                {
                    int currentPoint = int.Parse(matrix[moleRow, moleCol].ToString());
                    points += currentPoint;
                }

                matrix[moleRow, moleCol] = '-';
            }
            matrix[moleRow, moleCol] = 'M';

            if (points >= 25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
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

        private static bool IsPositionInField(char[,] matrix, int moleRow, int moleCol, int rows, int cols)
        {
            if (moleRow >= 0 && moleRow < rows && moleCol >= 0 && moleCol < cols)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
