﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4WildFarm
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }
        public string LivingRegion { get; set; }
    }
}
