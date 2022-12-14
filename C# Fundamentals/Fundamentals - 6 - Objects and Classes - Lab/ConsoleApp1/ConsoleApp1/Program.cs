using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');

            Random random = new Random();

            for (int i = 0; i < input.Length; i++)
            {
                int randomIndex = random.Next(0, input.Length);
                string currentWord = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = currentWord;

            }
            foreach (var word in input)
            {
                Console.WriteLine(word);
            }

        }
    }
}
