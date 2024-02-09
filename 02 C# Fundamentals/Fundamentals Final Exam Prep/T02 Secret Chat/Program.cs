using System;
using System.Linq;

namespace T02_Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string messages = Console.ReadLine();
            string[] commands = Console.ReadLine().Split(":|:");

            while (commands[0] != "Reveal")
            {
                switch (commands[0])
                {
                    case "InsertSpace":

                        int index = int.Parse(commands[1]);
                        messages = messages.Insert(index, " ");
                        break;
                    case "Reverse":

                        string substring = commands[1];

                        if (messages.Contains(substring))
                        {
                            int firstOccurance = messages.IndexOf(substring);
                            messages = messages.Remove(firstOccurance, substring.Length);
                            messages = messages + string.Join("", substring.Reverse());
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
                        string replacement = commands[2];
                        if (messages.Contains(existing))
                        {
                            messages = messages.Replace(existing, replacement);
                        }
                        break;

                }
                Console.WriteLine(messages);
                commands = Console.ReadLine().Split(":|:");
            }
            Console.WriteLine($"You have a new text message: {messages}");
        }
    }
}
