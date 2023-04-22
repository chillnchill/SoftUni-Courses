using System;
using System.Linq;

namespace T06_Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jaggedArray = new double[rows][];

            for (int row = 0; row < rows; row++)
            {
                double[] cols = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
                
                jaggedArray[row] = cols;
            }

            for (int row = 0; row < rows - 1; row++)
            {
                int currentRow = jaggedArray[row].Length;
                int nextRow = jaggedArray[row+1].Length;

                if (currentRow == nextRow)
                {
                   for (int col = 0; col < currentRow; col++)
                    {
                        jaggedArray[row][col] *= 2;
                        jaggedArray[row+1][col] *= 2;
                    }
                }
                else
                {
                    for (var col = 0; col < currentRow; col++)
                    {
                        jaggedArray[row][col] /= 2;
                    }
                    for (int col = 0; col < nextRow; col++)
                    {
                        jaggedArray[row+1][col] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ');

                string action = commands[0];

                if (action == "End")
                {
                    break;
                }
                else
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    double value = double.Parse(commands[3]);

                    if (row >= 0
                        && col >= 0
                        && row < jaggedArray.Length
                        && col < jaggedArray[row].Length)
                    {
                        if (action == "Add")
                        {
                            jaggedArray[row][col] += value;
                        }
                        if (action == "Subtract")
                        {
                            jaggedArray[row][col] -= value;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            foreach (double[] array in jaggedArray)
            {
                Console.WriteLine(String.Join(" ", array));
            }
        }
    }
}
