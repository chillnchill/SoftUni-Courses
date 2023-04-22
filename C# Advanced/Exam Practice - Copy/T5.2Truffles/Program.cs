using System;
using System.Linq;

namespace T5._2Truffles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int cols = n;
            char[,] matrix = new char[rows, cols];
            int blackTruffle = 0;
            int summerTruffle = 0;
            int whiteTruffle = 0;
            int boarTruffle = 0;
            bool isBoarActive = true;

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
                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0] == "Stop")
                {
                    break;
                }

                switch (commands[0])
                {
                    case "Collect":
                        int row = int.Parse(commands[1]);
                        int col = int.Parse(commands[2]);

                        if (matrix[row, col] == 'B')
                        {
                            blackTruffle++;
                        }
                        if (matrix[row, col] == 'S')
                        {
                            summerTruffle++;
                        }
                        if (matrix[row, col] == 'W')
                        {
                            whiteTruffle++;
                        }
                        matrix[row, col] = '-';
                        break;
                    case "Wild_Boar":
                        int boarRow = int.Parse(commands[1]);
                        int boarCol = int.Parse(commands[2]);
                        string direction = commands[3];

                        if (matrix[boarRow, boarCol] != '-')
                        {
                            boarTruffle++;
                            matrix[boarRow, boarCol] = '-';
                        }

                        while (true)
                        {
                            if (direction == "up")
                            {
                                if (IsWildBoarCellValid(boarRow - 2, boarCol, rows, cols))
                                {
                                    if (matrix[boarRow - 2, boarCol] != '-')
                                    {
                                        boarTruffle++;
                                        matrix[boarRow - 2, boarCol] = '-';
                                    }
                                    boarRow -= 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (direction == "down")
                            {
                                if (IsWildBoarCellValid(boarRow + 2, boarCol, rows, cols))
                                {
                                    if (matrix[boarRow + 2, boarCol] != '-')
                                    {
                                        boarTruffle++;
                                        matrix[boarRow + 2, boarCol] = '-';
                                    }
                                    boarRow += 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (direction == "left")
                            {
                                if (IsWildBoarCellValid(boarRow, boarCol - 2, rows, cols))
                                {
                                    if (matrix[boarRow, boarCol - 2] != '-')
                                    {
                                        boarTruffle++;
                                        matrix[boarRow, boarCol - 2] = '-';
                                    }
                                    boarCol -= 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            if (direction == "right")
                            {
                                if (IsWildBoarCellValid(boarRow, boarCol + 2, rows, cols))
                                {
                                    if (matrix[boarRow, boarCol + 2] != '-')
                                    {
                                        boarTruffle++;
                                        matrix[boarRow, boarCol + 2] = '-';
                                    }
                                    boarCol += 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                }
            }

            Console.WriteLine($"Peter manages to harvest {blackTruffle} black, {summerTruffle} summer, and {whiteTruffle} white truffles.");

            Console.WriteLine($"The wild boar has eaten {boarTruffle} truffles.");

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool IsWildBoarCellValid(int boarRow, int boarCol, int rows, int cols)
        {
            if (boarRow >= 0 && boarRow < rows && boarCol >= 0 && boarCol < cols)
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
