using System;
using System.Collections.Generic;
using System.Linq;

namespace T1._1FoodFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //vowels are queue
            //consonants are stack
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(' ').Select(char.Parse).ToList());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split(' ').Select(char.Parse).ToList());
            Dictionary<string, HashSet<char>> matches = new Dictionary<string, HashSet<char>>();

            matches.Add("pear", new HashSet<char>());
            matches.Add("flour", new HashSet<char>());
            matches.Add("pork", new HashSet<char>());
            matches.Add("olive", new HashSet<char>());
            
            while (consonants.Count > 0)
            {
                char currentVowel = vowels.Dequeue();
                char currentConsonant = consonants.Pop();

                foreach (var product in matches)
                {
                    if (product.Key.Contains(currentVowel))
                    {
                        product.Value.Add(currentVowel);
                    }
                    if (product.Key.Contains(currentConsonant))
                    {
                        product.Value.Add(currentConsonant);
                    }
                }
                vowels.Enqueue(currentVowel);
            }

            List<string> foundWords = matches
                .Where(w => w.Key.Count() == w.Value.Count)
                .Select(w => w.Key)
                .ToList();

            Console.WriteLine($"Words found: {foundWords.Count}");
            foreach (var word in foundWords)
            {
                Console.WriteLine(word);
            }
            
        }
    }
}
