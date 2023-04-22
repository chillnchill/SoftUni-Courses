using System;

namespace T02_Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string password = Console.ReadLine();
            string passwordAttempt = Console.ReadLine();

            while (passwordAttempt != password)
            {
                passwordAttempt = Console.ReadLine();
            }
            Console.WriteLine($"Welcome {userName}!");

        }

    }
}
