using System;

namespace T07_Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());
            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int space = l * w * h;
            string input = Console.ReadLine();

            while (input != "Done")
            {
                int boxes = int.Parse(input);

                if (space > boxes)
                {
                    space -= boxes;
                }
                else
                {
                    Console.WriteLine($"No more free space! You need {Math.Abs(space - boxes)} Cubic meters more.");
                    break;
                }
                input = Console.ReadLine();
            }

            if (input == "Done")
            {
                Console.WriteLine($"{space} Cubic meters left.");
            }
        }
    }
}
