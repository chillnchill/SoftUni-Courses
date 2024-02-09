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

        protected Vehicle(double increasedConsumption, double fuelQuantity, double fuelConsumtion)
        {
            this.increasedConsumption = increasedConsumption;
            FuelQuantity = fuelQuantity;
            FuelConsumtion = fuelConsumtion;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsumtion { get; private set; }

        public string Drive(double distance)
        {
            if (FuelQuantity < distance * (FuelConsumtion + increasedConsumption))
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= distance * (FuelConsumtion + increasedConsumption);

            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount) => FuelQuantity = amount;

        public override string ToString() =>
            $"{this.GetType().Name}: {FuelQuantity:f2}";
    }
}
