using System;

namespace T1._2PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int board = 8;
            char[,] matrix = new char[board, board];
            int blackStartRow = 0;
            int blackStartCol = 0;
            int whiteStartRow = 0;
            int whiteStartCol = 0;


            for (int row = 0; row < board; row++)
            {
                string values = Console.ReadLine();

                for (int col = 0; col < board; col++)
                {
                    matrix[row, col] = values[col];
                    if (matrix[row, col] == 'b')
                    {
                        blackStartRow = row;
                        blackStartCol = col;
                    }
                    if (matrix[row, col] == 'w')
                    {
                        whiteStartRow = row;
                        whiteStartCol = col;
                    }
                }
            }

                IsValidCell(int row, int col, char[,] matrix);
            

            if (matrix[whiteStartRow - 1, whiteStartCol + 1] == 'b' || matrix[whiteStartRow - 1, whiteStartCol - 1] == 'b')
            {
                whiteStartRow--;
                blackStartCol += 97;
                char black = (char)blackStartCol;
                Console.WriteLine($"Game over! White capture on {black}{8 - whiteStartRow}.");
                return;
            }
            if (matrix[blackStartRow + 1, blackStartCol + 1] == 'w' || matrix[blackStartRow + 1, whiteStartCol - 1] == 'w')
            {
                blackStartRow++;
                whiteStartCol += 97;
                char white = (char)whiteStartCol;
                Console.WriteLine($"Game over! Black capture on {white}{8 - blackStartCol}.");
                return;
            }

            while (true)
            {
                
                whiteStartRow--;
                matrix[whiteStartRow, whiteStartCol] = 'w';
                if (whiteStartRow == 0)
                {
                    whiteStartCol += 97;
                    char white = (char)whiteStartCol;
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {white}8.");
                    return;
                }
                if (matrix[blackStartRow + 1, blackStartCol + 1] == 'w' || matrix[blackStartRow + 1, whiteStartCol - 1] == 'w')
                {
                    blackStartRow++;
                    whiteStartCol += 97;
                    char white = (char)whiteStartCol;
                    Console.WriteLine($"Game over! Black capture on {white}{8 - blackStartRow}.");
                    return;
                }
                //Console.WriteLine("------------------------------");
                //Console.WriteLine("------------------------------");
                //Console.WriteLine("------------------------------");
                //for (int row = 0; row < board; row++)
                //{
                //    for (int col = 0; col < board; col++)
                //    {
                //        Console.Write($"{matrix[row, col]}");
                //    }
                //    Console.WriteLine();
                //}
                blackStartRow++;
                matrix[blackStartRow, blackStartCol] = 'b';
                if (blackStartRow == 7)
                {
                    blackStartCol += 97;
                    char black = (char)blackStartCol;
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {black}1.");
                    return;
                }
                if (matrix[whiteStartRow - 1, whiteStartCol + 1] == 'b' || matrix[whiteStartRow - 1, whiteStartCol - 1] == 'b')
                {
                    whiteStartRow--;
                    blackStartCol += 97;
                    char black = (char)blackStartCol;
                    Console.WriteLine($"Game over! White capture on {black}{8 - whiteStartRow}.");
                    return;
                }
            }

        }

        
    }
}
