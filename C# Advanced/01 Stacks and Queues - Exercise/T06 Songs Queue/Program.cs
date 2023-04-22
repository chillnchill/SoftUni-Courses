using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ").ToArray();
            Queue<string> songList = new Queue<string>(songs);

           
            while (songList.Count > 0)
            {
                string[] commands = Console.ReadLine().Split(' ');
                string action = commands[0];

                switch (action)
                {
                    case "Play":
                        songList.Dequeue();                        
                        break;
                    case "Add":
                        string song = string.Join(" ", commands.Skip(1));
                        if (!songList.Contains(song))
                        {
                            songList.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songList));
                        break;

                }
            }
            Console.WriteLine("No more songs!");

        }
    }
}
