using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T4WildFarm.Interfaces;
using T4WildFarm.Models;

namespace T4WildFarm.Factories
{
    public static class AnimalFactory
    {
        public static IAnimal CreateAnimal(
            string[] animalInfo)
        {
            IAnimal animal = null;

            string type = animalInfo[0];
            string name = animalInfo[1];
            double weight = double.Parse(animalInfo[2]);

            if (type == "Cat" || type == "Tiger")
            {
                string region = animalInfo[3];
                string breed = animalInfo[4];

                if (type == "Cat")
                {
                    animal = new Cat(name, weight, region, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, region, breed);
                }

            }
            else if (type == "Hen" || type == "Owl")
            {
                double wingSize = double.Parse(animalInfo[3]);

                if (type == "Hen")
                {
                    animal = new Hen(name, weight, wingSize);
                }
                else
                {
                    animal = new Owl(name, weight, wingSize);
                }
            }
            else
            {
                string region = animalInfo[3];

                if (type == "Mouse")
                {
                    animal = new Mouse(name, weight, region);
                }
                else
                {
                    animal = new Dog(name, weight, region);
                }
            }

            return animal;
        }
    }
}
