using System;
using System.Collections.Generic;
using System.Linq;

namespace Plant_Discovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfPlants = int.Parse(Console.ReadLine());
            var plantRarity = new Dictionary<string, int>();
            var plantRating = new Dictionary<string, List<int>>();

            for (int i = 0; i < numOfPlants; i++)
            {
                string[] input = Console.ReadLine().Split("<->");
                string plant = input[0];
                int rarity = int.Parse(input[1]);

                if (!plantRarity.ContainsKey(plant))
                {
                    plantRarity.Add(plant, rarity);
                    plantRating.Add(plant, new List<int>());
                }
                else
                {
                    plantRarity[plant] = rarity;
                }
            }

            string[] commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Exhibition")
            {
                string plant = commands[1];

                switch (commands[0])
                {
                    case "Rate":
                        int rating = int.Parse(commands[2]);
                        if (plantRating.ContainsKey(plant))
                        {
                            plantRating[plant].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        int rarity = int.Parse(commands[2]);
                        if (plantRarity.ContainsKey(plant))
                        {
                            plantRarity[plant] = rarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        if (plantRating.ContainsKey(plant))
                        {
                            plantRating[plant].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine($"Plants for the exhibition:");
            foreach (var plant in plantRating)
            {
                var rarity = plantRarity[plant.Key];
                double rate = 0;
                if (plant.Value.Count == 0)
                {
                    rate = 0.00;
                }
                else
                {
                    rate = plantRating[plant.Key].Average();
                }
                Console.WriteLine($"- {plant.Key}; Rarity: {rarity}; Rating: {rate:f2}");
            }
        }
    }
}
