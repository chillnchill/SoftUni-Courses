using System;
using System.Collections.Generic;

namespace T03_House_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                string[] commands = Console.ReadLine().Split(" ");

                if (commands[2] == "going!" && guestList.Contains(commands[0]))
                {
                    Console.WriteLine($"{commands[0]} is already in the list!");
                }
                else if (commands[2] == "going!")
                {
                    guestList.Add(commands[0]);
                }
                else if (commands[2] == "not" && guestList.Contains(commands[0]))
                {
                    guestList.Remove(commands[0]);
                }
                else
                {
                    Console.WriteLine($"{commands[0]} is not in the list!");
                }
            }

            foreach (string guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
