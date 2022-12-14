using System;
using System.Collections.Generic;

namespace T11_Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split("||");
            var ledger = new Dictionary<string, List<int>>();

            while (commands[0] != "Sail")
            {
                string town = commands[0];
                int population = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);
                if (!ledger.ContainsKey(town))
                {
                    ledger.Add(town, new List<int>());
                    ledger[town].Add(population);
                    ledger[town].Add(gold);
                }
                else
                {
                    ledger[town][0] += population;
                    ledger[town][1] += gold;
                }
                commands = Console.ReadLine().Split("||");
            }

            commands = Console.ReadLine().Split("=>");

            while (commands[0] != "End")
            {

                string town = commands[1];

                switch (commands[0])
                {
                    case "Plunder":
                        int people = int.Parse(commands[2]);
                        int gold = int.Parse(commands[3]);
                        ledger[town][0] -= people;
                        ledger[town][1] -= gold;

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");

                        if (ledger[town][0] <= 0 || ledger[town][1] <= 0)
                        {
                            Console.WriteLine($"{town} has been wiped off the map!");
                            ledger.Remove(town);
                        }

                        break;
                    case "Prosper":
                        int treasury = int.Parse(commands[2]);
                        if (treasury < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            commands = Console.ReadLine().Split("=>");
                            continue;
                        }
                        else
                        {
                            ledger[town][1] += treasury;
                            Console.WriteLine($"{treasury} gold added to the city treasury. {town} now has {ledger[town][1]} gold.");
                        }
                        break;


                }
                commands = Console.ReadLine().Split("=>");
            }

            if (ledger.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {ledger.Count} wealthy settlements to go to:");

                foreach (var city in ledger)
                {
                    Console.WriteLine($"{city.Key} -> Population: {city.Value[0]} citizens, Gold: {city.Value[1]} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
