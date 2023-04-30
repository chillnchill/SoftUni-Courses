using System;
using System.Collections.Generic;
using System.Text;

namespace T04PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;
        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniquesCalories;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            flourTypesCalories =
            new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };

            bakingTechniquesCalories =
                new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
        }

        public string FlourType { get; set; }
        public string BakingTechnique { get; set; }
        public int Weight { get; set; }


    }
}
