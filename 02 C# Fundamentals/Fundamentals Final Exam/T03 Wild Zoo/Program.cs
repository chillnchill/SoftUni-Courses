using System;
using System.Collections.Generic;

namespace T03_Wild_Zoo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            var animalLedger = new Dictionary<string, int>();
            var areaLedger = new Dictionary<string, List<string>>();
            var inverse = new Dictionary<string, List<string>>();

            while (commands[0] != "EndDay")
            {
                string action = commands[0];
                string animal = commands[1];
                int foodQuant = int.Parse(commands[2]);

                if (action == "Add")
                {
                    string area = commands[3];
                    if (!animalLedger.ContainsKey(animal))
                    {
                        animalLedger.Add(animal, foodQuant);                     
                        inverse.Add(animal, new List<string> { area });
                        if (areaLedger.ContainsKey(area))
                        {
                            areaLedger[area].Add(animal);
                        }
                        else
                        {
                            areaLedger.Add(area, new List<string> { animal });
                        }
                        
                    }
                    else
                    {
                        animalLedger[animal] += foodQuant;
                    }
                }
                else
                {
                    if (animalLedger.ContainsKey(animal))
                    {
                        animalLedger[animal] -= foodQuant;
                    }
                    else
                    {
                        commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                        continue;
                    }
                    if (animalLedger[animal] <= 0)
                    {
                        animalLedger.Remove(animal);
                        var zone = inverse[animal][0];
                        if (areaLedger[zone].Count > 1)
                        {
                            areaLedger[zone].Remove(animal);
                        }
                        else
                        {
                            areaLedger.Remove(zone);
                        }
                       

                        Console.WriteLine($"{animal} was successfully fed");
                    }
                }

                commands = Console.ReadLine().Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
            }
            Console.WriteLine("Animals:");
            foreach (var animal in animalLedger)
            {
                Console.WriteLine($" {animal.Key} -> {animal.Value}g");
            }
            Console.WriteLine("Areas with hungry animals:");
            foreach (var pin in areaLedger)
            {
                Console.WriteLine($" {pin.Key}: {pin.Value.Count}");
            }

            //if animalFood is ez
            //areaCount would be all the areas, if we get an area more than once we ++,
            //but how to reach it when an animal is removed?

        }
    }
}
