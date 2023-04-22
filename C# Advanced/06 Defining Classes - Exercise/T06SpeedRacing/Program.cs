using System;
using System.Collections.Generic;

namespace T06SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfcars = int.Parse(Console.ReadLine());
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            for (int i = 0; i < numberOfcars; i++)
            {
                string[] carInfo = Console.ReadLine().Split(' ');
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsumptionFor1km = double.Parse(carInfo[2]);
                double distanceTravelled = 0;
                Car car = new Car(model, fuelAmount, fuelConsumptionFor1km, distanceTravelled);
                cars.Add(model, car);
            }

            
            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0] == "End")
                {
                    break;
                }

                string model = commands[1];
                double kmToTravel = double.Parse(commands[2]);

                Car car = cars[model];

                car.IsThereEnoughFuel(kmToTravel);

            }

            foreach (Car car in cars.Values)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
