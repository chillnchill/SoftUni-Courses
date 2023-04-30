using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm
{
    public class Owl : Bird, IHoot
    {
        private const double Modifier = 0.25;
        public Owl(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override string WantFood()
        {
            return "Hoot Hoot";
        }

        public override void Eat(IFood food)
        {
            if (food is Meat)
            {
                Weight += food.Quantity * Modifier;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
    }
}
