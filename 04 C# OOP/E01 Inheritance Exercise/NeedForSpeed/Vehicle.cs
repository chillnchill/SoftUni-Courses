using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption  = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public virtual double FuelConsumption
        {
            get { return FuelConsumption; }
            set
            {
                FuelConsumption = DefaultFuelConsumption;
            }
        }
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            if (Fuel - (FuelConsumption * kilometers) >= 0)
            {
                Fuel -= FuelConsumption * kilometers;
            }
        }
    }
}
