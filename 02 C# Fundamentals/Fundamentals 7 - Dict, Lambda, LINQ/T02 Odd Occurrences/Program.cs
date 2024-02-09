using System;
using System.Collections.Generic;
using System.Linq;

namespace T02_Odd_Occurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordCount = new Dictionary<string, int>();

            string[] words = Console.ReadLine().ToLower().Split();

            for (int i = 0; i < words.Length; i++)
            {
                if (!wordCount.ContainsKey(words[i]))
                {
                    wordCount.Add(words[i], 0);
                }
                wordCount[words[i]]++;
            }

            string[] oddWordCount = wordCount
                .Where(w => w.Value % 2 != 0)
                .Select(w => w.Key)
                .ToArray();

            Console.WriteLine(string.Join(" ", oddWordCount));
        }
    }
}
