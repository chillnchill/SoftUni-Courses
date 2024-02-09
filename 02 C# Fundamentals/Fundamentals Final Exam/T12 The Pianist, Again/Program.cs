using System;
using System.Collections.Generic;

namespace T12_The_Pianist__Again
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPieces = int.Parse(Console.ReadLine());
            var pieceComposer = new Dictionary<string, List<string>>();
            var pieceKey = new Dictionary<string, List<string>>();

            for (int i = 0; i < numOfPieces; i++)
            {
                string[] music = Console.ReadLine().Split("|");
                string piece = music[0];
                string composer = music[1];
                string key = music[2];

                if (!pieceComposer.ContainsKey(piece))
                {
                    pieceComposer.Add(piece, new List<string>());
                    pieceComposer[piece].Add(composer);
                    pieceKey.Add(piece, new List<string>());
                    pieceKey[piece].Add(key);
                }

            }

            string[] commands = Console.ReadLine().Split("|");

            while (commands[0] != "Stop")
            {
                string piece = commands[1];
                switch (commands[0])
                {
                    case "Add":
                        string composer = commands[2];
                        string key = commands[3];
                        if (!pieceComposer.ContainsKey(piece))
                        {
                            pieceComposer.Add(piece, new List<string>());
                            pieceComposer[piece].Add(composer);
                            pieceKey.Add(piece, new List<string>());
                            pieceKey[piece].Add(key);
                            Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                        }
                        else
                        {
                            Console.WriteLine($"{piece} is already in the collection!");
                        }
                        break;
                    case "Remove":
                        if (pieceComposer.ContainsKey(piece))
                        {
                            pieceComposer.Remove(piece);
                            pieceKey.Remove(piece);
                            Console.WriteLine($"Successfully removed {piece}!");
                        }
                        else
                        {
                            Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                        }
                        break;
                    case "ChangeKey":
                        string newKey = commands[2];
                        if (pieceComposer.ContainsKey(piece))
                        {
                            pieceKey[piece][0] = newKey;
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
            
            foreach (var (key, value) in pieceComposer)
            {
                
                Console.WriteLine($"{key} -> Composer: {value[0]}, Key: {pieceKey[key][0]}");
            }
        }
    }
}
