﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T1Vehicles.Models;

namespace T2VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double IncreasedConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity, IncreasedConsumption)
        {

        }
    }
}
