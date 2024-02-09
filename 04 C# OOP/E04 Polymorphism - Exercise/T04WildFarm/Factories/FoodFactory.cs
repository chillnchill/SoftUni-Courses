using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;

namespace T4WildFarm.Factories
{
    public static class FoodFactory
    {
        public static IFood CreateFood(
            string[] foodInfo)
        { 
            IFood food = null;

            string foodType = foodInfo[0];
            int foodQuant = int.Parse(foodInfo[1]);
           

            if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuant);
            }
            else if (foodType == "Fruit")
            {
                food = new Fruit(foodQuant);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuant);
            }
            else
            {
                food = new Seeds(foodQuant);
            }

            return food;
        }
    }
}
