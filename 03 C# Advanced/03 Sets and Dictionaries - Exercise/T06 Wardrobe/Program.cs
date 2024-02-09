using System;
using System.Collections.Generic;

namespace T06_Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfClothingPieces = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> sortingTheMess = new Dictionary<string, Dictionary<string, int>>();
            

            for (int i = 0; i < numOfClothingPieces; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string color = input[0];
                string[] article = input[1].Split(',');

                if (!sortingTheMess.ContainsKey(color))
                {
                    sortingTheMess.Add(color, new Dictionary<string, int>());
                }

                foreach (var piece in article)
                {
                    if (!sortingTheMess[color].ContainsKey(piece))
                    {
                        sortingTheMess[color][piece] = 0;
                    }
                    sortingTheMess[color][piece]++;
                }
            }

            string[] sought = Console.ReadLine().Split(" ");

            foreach (var piece in sortingTheMess)
            {
                Console.WriteLine($"{piece.Key} clothes:");

                foreach (var count in piece.Value)
                {
                    string clr = sought[0];
                    string clthArticle = sought[1];
                    if (piece.Key == clr && count.Key == clthArticle)
                    {
                        Console.WriteLine($"* {count.Key} - {count.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {count.Key} - {count.Value}");
                }
            }
        }
    }
}
