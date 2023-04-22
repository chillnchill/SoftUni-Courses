using System;

namespace T06_Vowels_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int lengthOfWord = word.Length;
            int sum = 0;

            for (int i = 0; i < lengthOfWord; i++)
            {
                char currentLetter = word[i];
                switch (currentLetter)
                {
                    case 'a':
                        sum++; break;
                    case 'e':
                        sum += 2; break;
                    case 'i':
                        sum += 3; break;
                    case 'o':
                        sum += 4; break;
                    case 'u':
                        sum += 5;
                        break;
                }

            }
            Console.WriteLine(sum);
        }
    }
}
