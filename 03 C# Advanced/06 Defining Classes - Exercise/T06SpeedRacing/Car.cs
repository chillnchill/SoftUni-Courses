using System;
using System.Collections.Generic;
using System.Text;

namespace T06SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer, double travelledDistance)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = travelledDistance;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance  { get; set; }

        public void IsThereEnoughFuel(double travelledDistance)
        {
            
            if ((travelledDistance * FuelConsumptionPerKilometer) > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                TravelledDistance += travelledDistance;
                FuelAmount -= travelledDistance * this.FuelConsumptionPerKilometer;                             
            }
        }
    }
}
