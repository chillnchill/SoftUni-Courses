using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EncapsulationExercise
{
    public class Person
    {
        private string name;
        private decimal money;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<Product>();
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        public decimal Money
        {
            get => money;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

        public string AddProduct(Product product)
        {
            if (Money < product.Cost)
            {
                return $"{Name} can't afford {product.Name}";
            }
            Money -= product.Cost;
            BagOfProducts.Add(product);
            return $"{Name} bought {product.Name}";
        }

        public List<Product> BagOfProducts { get; set; }

        public override string ToString()
        {
            string productsString = BagOfProducts.Any()
                 ? string.Join(", ", BagOfProducts)
                 : "Nothing bought";

            return $"{Name} - {productsString}";
        }
    }
}
