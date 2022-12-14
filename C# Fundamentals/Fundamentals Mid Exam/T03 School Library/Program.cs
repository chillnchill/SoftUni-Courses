using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_School_Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> shelf = Console.ReadLine().Split("&").ToList();
            string[] commands = Console.ReadLine().Split(" | ");

            while (commands[0] != "Done")
            {
                switch (commands[0])
                {
                    case "Add Book":

                        if (shelf.Contains(commands[1]))
                        {
                            break;                            
                        }
                        shelf.Insert(0, commands[1]);
                        break;
                    case "Take Book":

                        if (shelf.Contains(commands[1]))
                        {
                            shelf.Remove(commands[1]);
                        }
                        break;
                    case "Swap Books":
                        if (shelf.Contains(commands[1]) && shelf.Contains(commands[2]))
                        {
                            int firstBook = shelf.IndexOf(commands[1]);
                            int secondBook = shelf.IndexOf(commands[2]);
                            shelf[secondBook] = commands[1];
                            shelf[firstBook] = commands[2];
                        }
                        break;
                    case "Insert Book":
                        if (shelf.Contains(commands[1]))
                        {
                            break;
                        }
                        shelf.Add(commands[1]);
                        break;
                    case "Check Book":
                        int index = int.Parse(commands[1]);
                        if (index < 0 || index > shelf.Count - 1)
                        {       
                            break;
                        }
                        Console.WriteLine(shelf[index]);
                        break;
                }
                commands = Console.ReadLine().Split(" | ");
            }
            Console.WriteLine(String.Join(", ", shelf));
        }
    }
}
