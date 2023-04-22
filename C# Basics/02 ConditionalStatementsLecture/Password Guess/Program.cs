using System;

namespace Password_Guess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = "s3cr3t!P@ssw0rd";
            string whatsThePassword = Console.ReadLine();

            bool correctPassword = whatsThePassword == password;

            if (correctPassword)
            {
                Console.WriteLine("Welcome");
            }
            else
            {

                Console.WriteLine("Wrong password!");
            }

        }
    }
}
