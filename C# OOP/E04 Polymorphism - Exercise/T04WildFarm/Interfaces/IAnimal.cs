using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T4WildFarm.Interfaces
{
    public interface IAnimal : IFood
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        public void Eat(IFood food);
        public string WantFood();
    }
}
