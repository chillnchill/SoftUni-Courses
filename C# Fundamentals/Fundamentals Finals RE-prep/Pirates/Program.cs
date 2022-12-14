using System;
using System.Collections.Generic;

namespace Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split("||");
            var cityPop = new Dictionary<string, int>();
            var cityGold = new Dictionary<string, int>();

            while (commands[0] != "Sail")
            {
                string town = commands[0];
                int pop = int.Parse(commands[1]);
                int gold = int.Parse(commands[2]);
                if (!cityPop.ContainsKey(town))
                {
                    cityPop.Add(town, pop);
                    cityGold.Add(town, gold);
                }
                else
                {
                    cityPop[town] += pop;
                    cityGold[town] += gold;
                }
                commands = Console.ReadLine().Split("||");
            }

            commands = Console.ReadLine().Split("=>");

            while (commands[0] != "End")
            {
                string action = commands[0];
                string town = commands[1];

                if (action == "Plunder")
                {
                    int pop = int.Parse(commands[2]);
                    int gold = int.Parse(commands[3]);
                    cityPop[town] -= pop;
                    cityGold[town] -= gold;
                    int currentPop = cityPop[town];
                    int currentGold = cityGold[town];

                    Console.WriteLine($"{town} plundered! {gold} gold stolen, {pop} citizens killed.");

                    if (currentPop <= 0 || currentGold <= 0)
                    {
                        cityPop.Remove(town);
                        cityGold.Remove(town);
                        Console.WriteLine($"{town} has been wiped off the map!");
                    }
                }
                else
                {
                    int prosperedGold = int.Parse(commands[2]);

                    if (prosperedGold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                        commands = Console.ReadLine().Split("=>");
                        continue;
                    }
                    else
                    {
                        cityGold[town] += prosperedGold;
                        Console.WriteLine($"{prosperedGold} gold added to the city treasury. {town} now has {cityGold[town]} gold.");
                    }
                }
                commands = Console.ReadLine().Split("=>");
            }
            if (cityGold.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cityPop.Count} wealthy settlements to go to:");
                foreach (var town in cityPop)
                {
                    var gold = cityGold[town.Key];
                    Console.WriteLine($"{town.Key} -> Population: {town.Value} citizens, Gold: {gold} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }


        }
    }
}
