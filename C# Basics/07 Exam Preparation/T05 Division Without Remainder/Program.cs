using System;

namespace T05_Division_Without_Remainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int playerOneEggs = int.Parse(Console.ReadLine());
            int playerTwoEggs = int.Parse(Console.ReadLine());
            string outcome = Console.ReadLine();

            while (outcome != "End")
            {

                if (outcome == "one")
                {
                    playerTwoEggs--;
                }
                else
                {
                    playerOneEggs--;
                }


                if (playerOneEggs == 0 || playerTwoEggs == 0)
                {
                    break;                 
                }
                outcome = Console.ReadLine();
            }

            if (outcome == "End")
            {
                Console.WriteLine($"Player one has {playerOneEggs} eggs left.");
                Console.WriteLine($"Player two has {playerTwoEggs} eggs left.");
            }
            else
            {
                if (playerOneEggs == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {playerTwoEggs} eggs left.");

                }
                else if (playerTwoEggs == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {playerOneEggs} eggs left.");

                }
            }

        }
    }
}
