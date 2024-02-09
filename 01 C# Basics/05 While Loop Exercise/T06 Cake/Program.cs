using System;

namespace T06_Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());
            int cake = cakeWidth * cakeLength;
            string input = Console.ReadLine();

            while (input != "STOP")
            {
                int PiecesTaken = int.Parse(input);
                
                if (cake >= PiecesTaken)
                {
                    cake -= PiecesTaken;
                }
                else
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cake - PiecesTaken)} pieces more.");
                    break;
                }
                input = Console.ReadLine();
            }


            if (input == "STOP")
            {
                Console.WriteLine($"{cake} pieces are left.");
            }

        }
    }
}
