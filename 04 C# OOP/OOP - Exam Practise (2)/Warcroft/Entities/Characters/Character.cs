using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, IBag bag)
        {
            Name = name;
            BaseHealth = health;
            Health = health;
            BaseArmor = armor;
            Armor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;

        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.CharacterNameInvalid);
                }
                name = value;
            }
        }
        public double BaseHealth { get; private set; }
        public double Health
        {
            get => health;
            set
            {
                health = value;
                if (health <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }
                if (health > this.BaseHealth)
                {
                    health = this.BaseHealth;
                }
            }
        }

        public double BaseArmor { get; private set; }
        public double Armor
        {
            get => armor;
            set
            {
                armor = value;
                if (armor < 0)
                {
                    armor = 0;
                }
            }

        }
        public double AbilityPoints { get; }
        public IBag Bag { get; }
        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        //bottom two methods might not work due to not having a RETURN for !IsAlive
        public void TakeDamage(double hitPoints)
        {
            if (!IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }

            double currentArmor = Armor;
            Armor -= hitPoints;

            if (Armor < 0)
            {
                Armor = 0;
                double overmatch = hitPoints - currentArmor;
                Health -= overmatch;

                if (Health <= 0)
                {
                    IsAlive = false;
                }

            }

        }

        public void UseItem(Item item)
        {
            if (!IsAlive)
            {
                return;
            }

            item.AffectCharacter(this);

        }
    }
}