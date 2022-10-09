using System;

namespace T05_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string accountName = Console.ReadLine();
            string password = "";
            int accountLength = accountName.Length - 1;
            int passwordAttempts = 1;
            

            for (int i = accountLength; i >= 0; i--)
            {               
                password += accountName[i];
               
            }

            string attempt = Console.ReadLine();

            while (attempt != password)
            {
                Console.WriteLine("Incorrect password. Try again.");

                attempt = Console.ReadLine();
                passwordAttempts++;

                if (passwordAttempts >= 4)
                {
                    break;
                }

            }


            if (passwordAttempts >= 4 && attempt != password)
            {
                Console.WriteLine($"User {accountName} blocked!");
            }
            else
            {
                Console.WriteLine($"User {accountName} logged in.");
            }

        }
    }
}
