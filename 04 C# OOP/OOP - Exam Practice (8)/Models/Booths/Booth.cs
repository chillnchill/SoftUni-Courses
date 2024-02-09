using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            this.CurrentBill = 0;
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }

        }

        public IRepository<IDelicacy> DelicacyMenu { get; private set; }

        public IRepository<ICocktail> CocktailMenu { get; private set; }

        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; } = false;

        public void ChangeStatus()
        {
            if (!IsReserved)
            {
                IsReserved = true;
            }
            else
            {
                IsReserved = false;
            }
        }

        public void Charge()
        {
            this.Turnover = this.CurrentBill;
            CurrentBill = 0;

        }

        public void UpdateCurrentBill(double amount) => this.CurrentBill += amount;

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Booth: {this.BoothId}");
            result.AppendLine($"Capacity: {this.Capacity}");
            result.AppendLine($"Turnover: {this.Turnover:f2} lv");
            result.AppendLine("-Cocktail menu:");
            foreach (ICocktail cocktail in CocktailMenu.Models)
            {
                result.AppendLine(cocktail.ToString());
            }
            result.AppendLine("-Delicacy menu:");
            foreach (IDelicacy delicacy in DelicacyMenu.Models)
            {
                result.AppendLine(delicacy.ToString());
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
