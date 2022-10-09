using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> initial = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string commands;

            while ((commands = Console.ReadLine()) != "end")
            {
                string[] commandsParsed = commands.Split();

                switch (commandsParsed[0])
                {
                    case "Add":
                        initial.Add(int.Parse(commandsParsed[1]));
                        break;
                    case "Remove":
                        initial.Remove(int.Parse(commandsParsed[1]));
                        break;
                    case "RemoveAt":
                        initial.RemoveAt(int.Parse(commandsParsed[1]));
                        break;
                    case "Insert":
                        initial.Insert(int.Parse(commandsParsed[2]), int.Parse(commandsParsed[1]));
                        break;
                }
            }
            Console.WriteLine(String.Join(" ", initial));
        }
    }
}
