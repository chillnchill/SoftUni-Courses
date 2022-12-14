using System;
using System.Collections.Generic;
using System.Linq;

namespace T15_Plants
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPlants = int.Parse(Console.ReadLine());
            var rarityLedger = new Dictionary<string, List<int>>();
            var ratingLedger = new Dictionary<string, List<double>>();


            for (int i = 0; i < numberOfPlants; i++)
            {
                string[] currentPlant = Console.ReadLine().Split("<->");
                string plant = currentPlant[0];
                int rarity = int.Parse(currentPlant[1]);

                if (!rarityLedger.ContainsKey(plant))
                {
                    rarityLedger.Add(plant, new List<int>());
                    ratingLedger.Add(plant, new List<double>());
                    rarityLedger[plant].Add(rarity);
                }
                rarityLedger[plant][0] = rarity;
            }

            string[] commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

            while (commands[0] != "Exhibition")
            {
                string plantName = commands[1];

                switch (commands[0])
                {
                    case "Rate":
                        if (ratingLedger.ContainsKey(plantName))
                        {
                            double rating = double.Parse(commands[2]);
                            ratingLedger[plantName].Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        if (ratingLedger.ContainsKey(plantName))
                        {
                            int newRarity = int.Parse(commands[2]);
                            rarityLedger[plantName][0] = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        if (ratingLedger.ContainsKey(plantName))
                        {
                            ratingLedger[plantName].Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine("Plants for the exhibition:");


            foreach (var plant in rarityLedger)
            {
                double averageRating = 0.0;
                int rarity = plant.Value[0];

                if (ratingLedger[plant.Key].Count > 0)
                {
                    averageRating = ratingLedger[plant.Key].Average();
                }

                Console.WriteLine($"- {plant.Key}; Rarity: {rarity}; Rating: {averageRating:f2}");
            }
        }
    }
}
