using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        public Car(
            string model,
        int engineSpeed,
        int enginePower,
        int cargoWeight,
        string cargoType,
        double tire1pressure,
        int tire1age,
        double tire2pressure,
        int tire2age,
        double tire3pressure,
        int tire3age,
        double tire4pressure,
        int tire4age
            )
        {
            Model = model;
            Engine = new Engine { Power = enginePower, Speed = engineSpeed };
            Cargo = new Cargo { Type = cargoType, Weight = cargoWeight };
            Tires = new Tires[4];
            Tires[0] = new Tires { Pressure = tire1pressure, Age = tire1age };
            Tires[1] = new Tires { Pressure = tire2pressure, Age = tire2age };
            Tires[2] = new Tires { Pressure = tire3pressure, Age = tire3age };
            Tires[3] = new Tires { Pressure = tire4pressure, Age = tire4age };

        }
        public string Model { get; set; }

        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tires[] Tires { get; set; }

    }
}
