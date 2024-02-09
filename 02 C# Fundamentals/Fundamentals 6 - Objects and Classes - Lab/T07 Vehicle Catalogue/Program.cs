using System;
using System.Collections.Generic;
using System.Linq;

namespace T07_Vehicle_Catalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            string[] vehicles = Console.ReadLine().Split('/');

            while (vehicles[0] != "end")
            {
                if (vehicles[0] == "Car")
                {
                    Car car = new Car()
                    {
                        Brand = vehicles[1],
                        Model = vehicles[2],
                        HorsePower = int.Parse(vehicles[3]),
                    };
                    catalogue.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck()
                    {
                        Brand = vehicles[1],
                        Model = vehicles[2],
                        Weight = int.Parse(vehicles[3]),
                    };
                    catalogue.Trucks.Add(truck);
                }
                vehicles = Console.ReadLine().Split('/');
            }
            if (catalogue.Cars.Count > 0)
            {
                List<Car> orderedCars = catalogue.Cars.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Cars:");
                foreach (var car in orderedCars)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                List<Truck> orderedTrucks = catalogue.Trucks.OrderBy(c => c.Brand).ToList();
                Console.WriteLine("Trucks:");
                foreach (var truck in orderedTrucks)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }

        }
    }
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Catalogue
    {

        public Catalogue()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
