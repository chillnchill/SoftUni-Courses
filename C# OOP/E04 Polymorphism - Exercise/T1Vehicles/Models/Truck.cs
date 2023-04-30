﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T1Vehicles.Models
{
    
    public class Truck : Vehicle
    {
        private const double IncreasedConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumtion)
            : base(IncreasedConsumption, fuelQuantity, fuelConsumtion)
        {
        }
        public override void Refuel(double amount)
       => base.Refuel(amount * 0.95);
    }
}
