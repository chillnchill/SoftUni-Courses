using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace T01TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> whiteTiles = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            Queue<int> grayTiles = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToList());
            SortedDictionary<string, int> surface = new SortedDictionary<string, int>();
            int sum = 0;


            while (whiteTiles.Count > 0)
            {
                if (grayTiles.Count == 0)
                {
                    break;
                }
                
                if (whiteTiles.Peek().ToString() == grayTiles.Peek().ToString())
                {
                    sum = whiteTiles.Pop() + grayTiles.Dequeue();
                }
                else
                {
                    var wTile = whiteTiles.Pop() / 2;
                    whiteTiles.Push(wTile);
                    var gTile = grayTiles.Dequeue();
                    grayTiles.Enqueue(gTile);
                    continue;
                }
                

                switch (sum)
                {
                    case 40:
                        if (!surface.ContainsKey("Sink"))
                        {
                            surface.Add("Sink", 0);      
                        }
                        surface["Sink"]++;
                        break;
                    case 50:
                        if (!surface.ContainsKey("Oven"))
                        {
                            surface.Add("Oven", 0);
                        }
                        surface["Oven"]++;
                        break;
                    case 60:
                        if (!surface.ContainsKey("Countertop"))
                        {
                            surface.Add("Countertop", 0);
                        }
                        surface["Countertop"]++;
                        break;
                    case 70:
                        if (!surface.ContainsKey("Wall"))
                        {
                            surface.Add("Wall", 0);
                        }
                        surface["Wall"]++;
                        break;
                    default:
                        if (!surface.ContainsKey("Floor"))
                        {
                            surface.Add("Floor", 0);
                        }
                        surface["Floor"]++;
                        break;
                }

            }
            if (whiteTiles.Count == 0)
            {
                Console.WriteLine($"White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }

            if (grayTiles.Count == 0)
            {
                Console.WriteLine($"Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", grayTiles)}");
            }

            foreach (var surf in surface.OrderByDescending(v => v.Value))
            {
                Console.WriteLine($"{surf.Key}: {surf.Value}");
            }

        }
    }
}
