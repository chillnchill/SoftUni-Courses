using System;

namespace T07_Pascal_Triangle
{
    internal class Program
    {
        //redo the entire thing
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalArray = new long[n][];

            for (int row = 0; row < n; row++)
            {

                pascalArray[row] = new long[row + 1];

                for (int col = 0; col < pascalArray[row].Length; col++)
                {
                    if (row == 0)
                    {
                        pascalArray[row][col] = 1;
                        continue;
                    }
                    long currentValue = 0;

                    if (col > 0)
                    {
                        currentValue += pascalArray[row - 1][col - 1];
                    }

                    if (pascalArray[row].Length - 1 > col)
                    {
                        currentValue += pascalArray[row - 1][col];
                    }

                    pascalArray[row][col] = currentValue;
                }
            }
            for (long row = 0; row < pascalArray.Length; row++)
            {
                for (long col = 0; col < pascalArray[row].Length; col++)
                {
                    Console.Write($"{pascalArray[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
