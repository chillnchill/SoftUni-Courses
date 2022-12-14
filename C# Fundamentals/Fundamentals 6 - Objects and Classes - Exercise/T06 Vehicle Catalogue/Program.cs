using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T06_Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] initial = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Vehicle> vehicles = new List<Vehicle>();


            while (initial[0] != "End")
            {
                VehicleType vehicleType;
                bool isVehicleTypeLegit = Enum.TryParse(initial[0], true , out vehicleType);

                if (isVehicleTypeLegit)
                {
                    string vehicleModel = initial[1];
                    string vehicleColor = initial[2];
                    int vehicleHorsePower = int.Parse(initial[3]);

                    var currentVehicle = new Vehicle(vehicleType, vehicleModel, vehicleColor, vehicleHorsePower);
                    vehicles.Add(currentVehicle);
                }

                initial = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }



            while (true)
            {
                string cmds = Console.ReadLine();
                if (cmds == "Close the Catalogue")
                {
                    break;
                }
                var selectedVehicle = vehicles.FirstOrDefault(vehicle => vehicle.Model == cmds);

                Console.WriteLine(selectedVehicle);

            }

            var cars = vehicles.Where(vehicles => vehicles.Type == VehicleType.Car).ToList();
            var trucks = vehicles.Where(vehicles => vehicles.Type == VehicleType.Truck).ToList();

            double carsAverageHorsePower = cars.Count > 0 ? cars.Average(car => car.HorsePower) : 0.00;
            double trucksAverageHorsePower = trucks.Count > 0 ? trucks.Average(truck => truck.HorsePower) : 0.00;

            Console.WriteLine($"Cars have average horsepower of: {carsAverageHorsePower:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAverageHorsePower:f2}.");
        }
    }
    enum VehicleType
    {
        Car,
        Truck
    }

    class Vehicle
    {
        public Vehicle(VehicleType type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public VehicleType Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Type: {Type}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Color: {Color}");
            sb.AppendLine($"Horsepower: {HorsePower}");

            return sb.ToString().TrimEnd();
        }
    }
}
