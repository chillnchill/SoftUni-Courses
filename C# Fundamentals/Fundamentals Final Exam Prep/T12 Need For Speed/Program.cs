using System;
using System.Collections.Generic;

namespace T12_Need_For_Speed
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            var carStats = new Dictionary<string, List<int>>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] car = Console.ReadLine().Split("|");
                string model = car[0];
                int mileage = int.Parse(car[1]);
                int fuel = int.Parse(car[2]);

                if (!carStats.ContainsKey(model))
                {
                    carStats.Add(model, new List<int>());
                    carStats[model].Add(mileage);
                    carStats[model].Add(fuel);
                }

            }
            string[] commands = Console.ReadLine().Split(" : ");

            while (commands[0] != "Stop")
            {
                string model = commands[1];
                switch (commands[0])
                {
                    case "Drive":
                        {
                            int distance = int.Parse(commands[2]);
                            int fuel = (int.Parse(commands[3]));
                            Drive(model, distance, fuel, carStats);
                            break;
                        }
                    case "Refuel":
                        {
                            int fuel = (int.Parse(commands[2]));
                            Refuel(carStats, model, fuel);
                            break;
                        }
                    case "Revert":
                        {
                            int distance = (int.Parse(commands[2]));
                            Revert(carStats, model, distance);
                            break;
                        }

                }
                commands = Console.ReadLine().Split(" : ");
            }
            foreach (var car in carStats)
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value[0]} kms, Fuel in the tank: {car.Value[1]} lt.");
            }
        }

        static void Drive(string model, int distance, int fuel, Dictionary<string, List<int>> carStats)
        {
            if (carStats[model][1] >= fuel)
            {
                carStats[model][1] -= fuel;
                carStats[model][0] += distance;
                Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine("Not enough fuel to make that ride");
            }
            if (carStats[model][0] >= 100000)
            {
                Console.WriteLine($"Time to sell the {model}!");
                carStats.Remove(model);
            }
        }

        static void Refuel(Dictionary<string, List<int>> carStats, string model, int fuel)
        {
            int currentFuel = carStats[model][1];
            carStats[model][1] += fuel;
            if (carStats[model][1] > 75)
            {
                carStats[model][1] = 75;
                Console.WriteLine($"{model} refueled with {75 - currentFuel} liters");
                return;
            }
            Console.WriteLine($"{model} refueled with {fuel} liters");
        }

        static void Revert(Dictionary<string, List<int>> carStats, string model, int distance)
        {
            int currentKm = carStats[model][0];
            carStats[model][0] -= distance;
            if (carStats[model][0] < 10000)
            {
                carStats[model][0] = 10000;
                return;
            }
            Console.WriteLine($"{model} mileage decreased by {distance} kilometers");
        }
    }
}
