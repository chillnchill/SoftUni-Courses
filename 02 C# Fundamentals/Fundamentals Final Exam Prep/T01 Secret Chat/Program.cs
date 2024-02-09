using System;

namespace T01_Secret_Chat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(":");

            while (commands[0] != "Travel")
            {
                switch (commands[0])
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string value = commands[2];
                        if (index < stops.Length && index >= 0)
                        {
                            stops = stops.Insert(index, value);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        int span = endIndex - startIndex;
                        if (endIndex < stops.Length && startIndex >= 0)
                        {
                            stops = stops.Remove(startIndex, span+1);
                        }
                        break;
                    case "Switch":
                        string oldStop = commands[1];
                        string newStop = commands[2];
                        if (stops.Contains(oldStop))
                        {
                           stops = stops.Replace(oldStop, newStop);
                        }
                        break;
                }
                Console.WriteLine(stops);
                commands = Console.ReadLine().Split(":");
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");

        }
    }

}
