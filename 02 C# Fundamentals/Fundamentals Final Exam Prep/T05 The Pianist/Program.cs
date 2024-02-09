using System;
using System.Collections.Generic;

namespace T05_The_Pianist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPieces = int.Parse(Console.ReadLine());
            var noteBook = new Dictionary<string, KeyValuePair<string, string>>();
            var songList = new List<string>();

            for (int i = 0; i < numberOfPieces; i++)
            {
                string[] pieces = Console.ReadLine().Split("|");
                string piece = pieces[0];
                string composer = pieces[1];
                string key = pieces[2];
                if (!noteBook.ContainsKey(piece))
                {
                    noteBook.Add(piece, new KeyValuePair<string, string>(composer, key));
                    songList.Add(piece);
                }
            }
            string[] commands = Console.ReadLine().Split("|");

            while (commands[0] != "Stop")
            {
                string piece = commands[1];
                    
                switch (commands[0])
                {
                    case "Add":
                        if (!noteBook.ContainsKey(piece))
                        {
                            string composer = commands[2];
                            string key = commands[3];
                            noteBook.Add(piece, new KeyValuePair<string, string>(composer, key));
                            songList.Add(piece);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!"); 
                        }
                        break;
                    case "Remove":
                        if (noteBook.ContainsKey(piece))
                        {
                            noteBook.Remove(piece);
                            songList.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = commands[2];
                        if (noteBook.ContainsKey(piece))
                        {
                            var composser = noteBook[piece].Key;
                            noteBook[piece] = new KeyValuePair<string, string> ( composser, newKey );
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                }
                commands = Console.ReadLine().Split("|");
            }
            foreach (var song in songList)
            {
                Console.WriteLine($"{song} -> Composer: {noteBook[song].Key}, Key: {noteBook[song].Value}");
            }
        }
    }
}
