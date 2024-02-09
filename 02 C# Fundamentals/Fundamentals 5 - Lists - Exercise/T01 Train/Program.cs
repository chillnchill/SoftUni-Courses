using System;
using System.Collections.Generic;
using System.Linq;

namespace T01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> lagons = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int maxLagonCapacity = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ");

            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    lagons.Add(int.Parse(commands[1]));
                }
                else
                {
                    for (int i = 0; i < lagons.Count; i++)
                    {
                        if (lagons[i] + int.Parse(commands[0]) <= maxLagonCapacity)
                        {
                            lagons[i] += int.Parse(commands[0]);
                            break;
                        }                       
                    }
                }
                commands = Console.ReadLine().Split(" ");
            }

            Console.WriteLine(String.Join(" ", lagons));
        }
    }
}
