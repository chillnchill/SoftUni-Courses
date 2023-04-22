using System;
using System.Linq;

namespace T06_Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jagger = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                jagger[row] = new int[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    jagger[row][col] = input[col];
                }
            }

            string[] commands = Console.ReadLine().Split(' ');

            while (commands[0] != "END")
            {
                string action = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row >= 0 && row < jagger.Length && col >= 0 && col < jagger[row].Length)
                {
                    if (action == "Add")
                    {
                        jagger[row][col] += value;
                    }
                    else
                    {

                        jagger[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                    commands = Console.ReadLine().Split(' ');
                    continue;
                }
                commands = Console.ReadLine().Split(' ');
            }


            foreach (int[] array in jagger)
            {
                Console.WriteLine(String.Join(" ", array));
            }

        }
    }
}
