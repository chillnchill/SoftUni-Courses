using System;

namespace T10_Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Done")
            {
                switch (commands[0])
                {
                    case "TakeOdd":
                        string newPass = "";
                        for (int i = 0; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                newPass += $"{password[i]}";
                            }
                        }
                        password = newPass;
                            break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        string substring = password.Substring(index, length);
                        index = password.IndexOf(substring);
                        password = password.Remove(index, substring.Length);
                        break;
                    case "Substitute":
                        string current = commands[1];
                        string substitute = commands[2];
                        if (password.Contains(current))
                        {
                            password = password.Replace(current, substitute);                            
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                            commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                            continue;
                        }
                        break;
                }
                Console.WriteLine(password);
                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
