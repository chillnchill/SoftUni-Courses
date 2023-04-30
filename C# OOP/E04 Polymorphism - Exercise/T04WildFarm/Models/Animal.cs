using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public int Quantity { get; set; }

        public abstract void Eat(IFood food); 
        public abstract string WantFood();
        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, ";
        }
    }
}
