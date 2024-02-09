using System;

namespace World_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(':');

            while (commands[0] != "Travel")
            {
                switch (commands[0])
                {
                    case "Add Stop":
                        int index = int.Parse(commands[1]);
                        string stop = commands[2];
                        if (index >= 0 && index < stops.Length)
                        {
                            stops = stops.Insert(index, stop);                           
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);
                        if (startIndex >= 0 && startIndex < stops.Length && endIndex >= 0 && endIndex < stops.Length)
                        {
                           stops = stops.Remove(startIndex, endIndex - startIndex + 1);
                        }
                        break;
                    case "Switch":
                        string existing = commands[1];
                        string newStop = commands[2];
                        if (stops.Contains(existing))
                        {
                            stops = stops.Replace(existing, newStop);                            
                        }
                        break;
                }
                Console.WriteLine(stops);
                commands = Console.ReadLine().Split(':');
            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}
