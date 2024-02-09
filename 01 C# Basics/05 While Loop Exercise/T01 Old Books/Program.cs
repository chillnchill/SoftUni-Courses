using System;

namespace T02_Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string book = Console.ReadLine();
            string nextBook = "";
            int numberOfBooks = 0;

            while (nextBook != book)
            {
                nextBook = Console.ReadLine();

                if (nextBook == book)
                {
                    Console.WriteLine($"You checked {numberOfBooks} books and found it.");
                }
                else if (nextBook == "No More Books")
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {numberOfBooks} books.");
                    break;
                }
                numberOfBooks++;
            }

        }
    }
}
