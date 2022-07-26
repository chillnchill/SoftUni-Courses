﻿using System;
using System.Collections.Generic;

namespace T03_Word_Synonyms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfWords = int.Parse(Console.ReadLine());

            Dictionary<string, List<string>> pairs = new Dictionary<string, List<string>>();

            for (int i = 0; i < numberOfWords; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();

                if (!pairs.ContainsKey(word))
                {
                    pairs.Add(word, new List<string>());
                }

                pairs[word].Add(synonym);
            }

            foreach (var pair in pairs)
            {
                Console.WriteLine($"{pair.Key} - {string.Join(", ", pair.Value)}");
            }




        }
    }
}
