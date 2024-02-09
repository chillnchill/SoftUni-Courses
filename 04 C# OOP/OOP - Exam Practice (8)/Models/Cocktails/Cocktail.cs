using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size
        {
            get => size;
            private set
            {
                if (value == "Small" || value == "Middle" || value == "Large")
                {
                    size = value;
                }
            }

        }
        public double Price
        {
            get => price;
            private set
            {
                if (this.Size == "Large")
                {
                    price = value;
                }
                else if (this.Size == "Middle")
                {
                    price = value * (2.0 / 3.0);
                }
                else
                {
                    price = value * (1.0 / 3.0);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} ({this.Size}) - {this.Price:f2} lv");
            return result.ToString();
        }
    }
}
