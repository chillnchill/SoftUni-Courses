using System;

namespace T02_Common_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arrayOne = Console.ReadLine().Split(' ');
            string[] arrayTwo = Console.ReadLine().Split(' ');

            foreach (string currentElement in arrayOne)
            {
                for (int i = 0; i < arrayTwo.Length; i++)
                {
                    if (currentElement == arrayTwo[i])
                    {
                        Console.Write($"{currentElement} ");
                    }
                }
            }

        }
        
    }
}

