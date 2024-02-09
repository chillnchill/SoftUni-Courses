using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Factories;
using T4WildFarm.Interfaces;
using T4WildFarm.Models;

namespace T4WildFarm
{
    public class StartUp
    {

        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<IAnimal> animalList = new List<IAnimal>();

            while (input != "End")
            {
                string[] animalInfo = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string[] foodInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                IAnimal animal = AnimalFactory.CreateAnimal(animalInfo);
                IFood food = FoodFactory.CreateFood(foodInfo);

                Console.WriteLine(animal.WantFood());
                animalList.Add(animal);

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animalList)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

