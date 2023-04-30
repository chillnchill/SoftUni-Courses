using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm
{
    public class Hen : Bird, ICluck
    {
        private const double Modifier = 0.35;
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override void Eat(IFood food)
        {
            if (food is Food)
            {
                Weight += food.Quantity * Modifier;
                FoodEaten += food.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override string WantFood()
        {
            return "Cluck";
        }
    }
}
