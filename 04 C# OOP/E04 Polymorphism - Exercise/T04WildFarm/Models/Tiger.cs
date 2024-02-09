using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm.Models
{
    public class Tiger : Feline, IRoar
    {
        private const double Modifier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        public override string WantFood()
        {
            return "ROAR!!!";
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
