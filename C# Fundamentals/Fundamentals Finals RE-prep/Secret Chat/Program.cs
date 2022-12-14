using System;
using System.Linq;

namespace Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string chat = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(":|:");

            while (commands[0] != "Reveal")
            {
                switch (commands[0])
                {
                    case "InsertSpace":
                        {
                            int index = int.Parse(commands[1]);
                            chat = chat.Insert(index, " ");
                        }
                        break;
                    case "Reverse":
                        string sub = commands[1];
                        if (chat.Contains(sub))
                        {
                            int index = chat.IndexOf(sub);
                            chat = chat.Remove(index, sub.Length);
                            chat = chat + string.Join("", sub.Reverse());
                        }
                        else
                        {
                            Console.WriteLine("error");
                            commands = Console.ReadLine().Split(":|:");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        string existing = commands[1];
                        string replace = commands[2];
                        if (chat.Contains(existing))
                        {
                            chat = chat.Replace(existing, replace);
                        }
                        break;
                }
                Console.WriteLine(chat);
                commands = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {chat}");

        }
    }
}
