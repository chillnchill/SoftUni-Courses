﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

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
