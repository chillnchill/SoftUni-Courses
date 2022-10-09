using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_Cards_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> playerOne = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> playerTwo = Console.ReadLine().Split().Select(int.Parse).ToList();


            for (int i = 0; i < playerOne.Count; i++)
            {
                if (playerOne.Count == 0 || playerTwo.Count == 0)
                {
                    break;
                }
                if (playerOne[i] > playerTwo[i] && playerTwo.Count > 0)
                {
                    playerOne.Add(playerOne[i]);
                    playerOne.Add(playerTwo[i]);
                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                    i--;
                }
                else if (playerTwo[i] > playerOne[i] && playerOne.Count > 0)
                {
                    playerTwo.Add(playerTwo[i]);
                    playerTwo.Add(playerOne[i]);
                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                    i--;
                }
                else if (playerOne[i] == playerTwo[i])
                {
                    playerOne.RemoveAt(i);
                    playerTwo.RemoveAt(i);
                    i--;
                }
            }
            if (playerOne.Count > playerTwo.Count)
            {
                Console.WriteLine(playerOne.Sum());
            }
            else
            {
                Console.WriteLine(playerTwo.Sum());
            }
        }
    }
}
