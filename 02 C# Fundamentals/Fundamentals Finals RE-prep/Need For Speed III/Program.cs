using System;
using System.Collections.Generic;

namespace Need_For_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCars = int.Parse(Console.ReadLine());
            var carKm = new Dictionary<string, int>();
            var carFuel = new Dictionary<string, int>();

            for (int i = 0; i < numOfCars; i++)
            {
                string[] carDetails = Console.ReadLine().Split('|');
                string carName = carDetails[0];
                int mileage = int.Parse(carDetails[1]);
                int fuel = int.Parse(carDetails[2]);

                if (!carKm.ContainsKey(carName))
                {
                    carKm.Add(carName, mileage);
                    carFuel.Add(carName, fuel);
                }
            }

            string[] commands = Console.ReadLine().Split(" : ");

            while (commands[0] != "Stop")
            {
                string car = commands[1];
                switch (commands[0])
                {
                    case "Drive":
                        {
                            int distance = int.Parse(commands[2]);
                            int fuel = int.Parse(commands[3]);

                            Drive(carFuel, carKm, car, distance, fuel);

                        }
                        break;
                    case "Refuel":
                        {
                            int fuel = int.Parse(commands[2]);

                            Refuel(carFuel, car, fuel);

                        }
                        break;
                    case "Revert":
                        int km = int.Parse(commands[2]);

                        Revert(carKm, car, km);

                        break;
                }
                commands = Console.ReadLine().Split(" : ");
            }
            foreach (var car in carKm)
            {
                var fuel = carFuel[car.Key];
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value} kms, Fuel in the tank: {fuel} lt.");
            }
        }

        static void Drive(Dictionary<string, int> carFuel, Dictionary<string, int> carKm, string car, int distance, int fuel)
        {
            if (carFuel[car] >= fuel)
            {
                carKm[car] += distance;
                carFuel[car] -= fuel;
                Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
            }
            else
            {
                Console.WriteLine($"Not enough fuel to make that ride");
            }

            if (carKm[car] >= 100000)
            {
                Console.WriteLine($"Time to sell the {car}!");
                carKm.Remove(car);
                carFuel.Remove(car);
            }

        }

        static void Refuel(Dictionary<string, int> carFuel, string car, int fuel)
        {
            int currentFuel = carFuel[car] + fuel;
            carFuel[car] += fuel;

            if (carFuel[car] > 75)
            {
                carFuel[car] = 75;
                fuel = (fuel + 75) - currentFuel;
            }

            Console.WriteLine($"{car} refueled with {fuel} liters");
        }

        static void Revert(Dictionary<string, int> carKm, string car, int km)
        {
            carKm[car] -= km;

            if (carKm[car] < 10000)
            {
                carKm[car] = 10000;
                return;
            }

            Console.WriteLine($"{car} mileage decreased by {km} kilometers");
        }
    }
}
