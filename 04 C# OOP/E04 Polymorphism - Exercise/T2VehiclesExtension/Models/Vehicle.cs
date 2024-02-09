using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace T1Vehicles.Models
{
    public class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity, double increasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumtion = fuelConsumption;
            this.increasedConsumption = increasedConsumption;
        }


        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (TankCapacity < value)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsumtion { get; private set; }
        public double TankCapacity { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < distance * (FuelConsumtion + increasedConsumption))
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * (FuelConsumtion + increasedConsumption);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (amount + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }

            FuelQuantity += amount;
        }

        public string DriveEmpty(double distance)
        {
            if (FuelQuantity < distance * FuelConsumtion)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }
            FuelQuantity -= distance * FuelConsumtion;
            return $"{this.GetType().Name} travelled {distance} km";
        }


        public override string ToString() =>
            $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}
