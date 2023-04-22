using System;

namespace T05_Character_Sequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int lenghtOfWord = word.Length;
            

            for (int index = 0; index <= lenghtOfWord - 1; index++)
            {
                char current = word[index];
                Console.WriteLine(current);
            }


        }
    }
}
