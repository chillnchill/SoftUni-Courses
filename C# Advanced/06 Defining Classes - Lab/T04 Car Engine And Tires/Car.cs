using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        string make;
        string model;
        int year;
        double fuelQuantity;
        double fuelConsumption;

        public Car()
        {
            Make = "VW";
            Model = "Golf";
            Year = 2025;
            FuelQuantity = 200;
            FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        { 
            Make = make;
            Model = model;
            Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        {
            FuelConsumption = fuelConsumption;
            FuelQuantity = fuelQuantity;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this(make, model, year, fuelConsumption, fuelQuantity)
        {
            Engine = engine;
            Tires = tires;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }


        private Engine engine;
        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }

        private Tire[] tires;
        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void Drive(double distance)
        {
            double fuelLeft = fuelQuantity - (distance * fuelConsumption);

            if (fuelLeft < 0)
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
                return;
            }
            FuelQuantity -= fuelLeft;
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}";
        }
    }
    

    
}
