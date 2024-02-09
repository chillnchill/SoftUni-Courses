using System;

namespace Re_taking_finals
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
                        string sub = commands[1];
                        if (activationKey.Contains(sub))
                        {
                            Console.WriteLine($"{activationKey} contains {sub}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        {
                            string cmd = commands[1];
                            int start = int.Parse(commands[2]);
                            int end = int.Parse(commands[3]);
                            string subs = activationKey.Substring(start, end - start);
                            activationKey = activationKey.Remove(start, end - start);
                            if (cmd == "Upper")
                            {
                                subs = subs.ToUpper();                               
                                activationKey = activationKey.Insert(start, subs);
                            }
                            else
                            {
                                subs = subs.ToLower();
                                activationKey = activationKey.Insert(start, subs);
                            }
                            Console.WriteLine(activationKey);
                        }                     
                        break;
                    case "Slice":
                        {
                            int start = int.Parse(commands[1]);
                            int end = int.Parse(commands[2]);
                            activationKey = activationKey.Remove(start, end - start);
                            Console.WriteLine(activationKey);
                        }
                        break;
                }
                commands = Console.ReadLine().Split(">>>");
            }
            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
