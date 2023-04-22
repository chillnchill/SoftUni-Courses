using System;
using System.Collections.Generic;

namespace T05_Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> cityLocation = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < input; i++)
            {
                string[] cities = Console.ReadLine().Split(' ');
                string continent = cities[0];
                string country = cities[1];
                string city = cities[2];

                if (!cityLocation.ContainsKey(continent))
                {
                    cityLocation.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!cityLocation[continent].ContainsKey(country))
                {
                    cityLocation[continent].Add(country, new List<string>());
                }

                cityLocation[continent][country].Add(city);

            }

            foreach (var cont in cityLocation)
            {

                Console.WriteLine($"{cont.Key}:");

                foreach (var c in cont.Value)
                {
                    Console.WriteLine($"{c.Key} -> {string.Join(", ", c.Value)}");
                }
            }
        }
    }
}
