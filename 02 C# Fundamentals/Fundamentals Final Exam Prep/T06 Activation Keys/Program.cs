using System;
using System.Linq;

namespace T06_Activation_Keys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(">>>");

            while (commands[0] != "Generate")
            {
                switch (commands[0])
                {
                    case "Contains":
                        string substring = commands[1];
                        if (activationKey.Contains(substring))
                        {
                            Console.WriteLine($"{activationKey} contains {substring}");   
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                            commands = Console.ReadLine().Split(">>>");
                            continue;
                        }
                        break;
                    case "Flip":
                        {
                            int start = int.Parse(commands[2]);
                            int end = int.Parse(commands[3]);
                            string sub = activationKey.Substring(start, end - start);
                            activationKey = activationKey.Remove(start, sub.Length);
                            if (commands[1] == "Upper")
                            {
                                sub = sub.ToUpper();
                            }
                            else
                            {
                                sub = sub.ToLower();
                            }
                            activationKey = activationKey.Insert(start, sub);
                            Console.WriteLine(activationKey);
                        }
                        break;
                    case "Slice":
                        {
                            int start = int.Parse(commands[1]);
                            int end = int.Parse(commands[2]);

                            activationKey = activationKey.Remove(start, (end - start));
                        }
                        Console.WriteLine(activationKey);
                        break;
                }
                
                commands = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
