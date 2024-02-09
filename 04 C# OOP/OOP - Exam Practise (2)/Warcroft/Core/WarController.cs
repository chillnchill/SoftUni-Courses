using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Xml.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;
        public WarController()
        {
            characters = new List<Character>();
            items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string charType = args[0];
            string name = args[1];

            Character character = null;

            if (charType == nameof(Warrior))
            {
                character = new Warrior(name);
                characters.Add(character);
            }
            else if (charType == nameof(Priest))
            {
                character = new Priest(name);
                characters.Add(character);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, charType));
            }
            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];
            Item item = null;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
                items.Add(item);
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
                items.Add(item);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
            }

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string charName = args[0];

            Character character = characters.FirstOrDefault(c => c.Name == charName);

            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charName));
            }
            if (!items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Item item = items.LastOrDefault();
            items.Remove(item);
            character.Bag.AddItem(item);

            return string.Format(SuccessMessages.PickUpItem, charName, item.GetType().Name);

        }

        public string UseItem(string[] args)
        {
            string charName = args[0];
            string itemName = args[1];
            Character character = characters.FirstOrDefault(c => c.Name == charName);


            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, charName));
            }

            Item item = character.Bag.GetItem(itemName);
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, charName, itemName);
        }

        public string GetStats()
        {

            StringBuilder result = new StringBuilder();
            string lifeStatus = "Alive";


            foreach (Character character in characters.OrderByDescending(x => x.IsAlive).ThenByDescending(x => x.Health))
            {
                if (!character.IsAlive)
                {
                    lifeStatus = "Dead";
                }
                result.AppendLine(string.Format(SuccessMessages.CharacterStats, character.Name
                    , character.Health
                    , character.BaseHealth
                    , character.Armor
                    , character.BaseArmor
                    , lifeStatus));
            }

            return result.ToString().TrimEnd();
        }

        public string Attack(string[] args)
        {
            string at = args[0];
            string re = args[1];

            StringBuilder result = new StringBuilder();
            Character attacker = characters.FirstOrDefault(c => c.Name == at);
            Character receiver = characters.FirstOrDefault(c => c.Name == re);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, at));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, re));
            }
            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, at));
            }

            ((IAttacker)attacker).Attack(receiver);


            result.AppendLine(string.Format(SuccessMessages.AttackCharacter
          , attacker.Name, receiver.Name, attacker.AbilityPoints
          , receiver.Name, receiver.Health, receiver.BaseHealth
          , receiver.Armor, receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
                result.AppendLine(string.Format(string.Format(SuccessMessages.AttackKillsCharacter, re)));
            }

            return result.ToString().TrimEnd();

        }

        public string Heal(string[] args)
        {
            string he = args[0];
            string re = args[1];


            Character healer = characters.FirstOrDefault(c => c.Name == he);
            Character receiver = characters.FirstOrDefault(c => c.Name == re);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, he));
            }
            if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, re));
            }
            if (!(healer is IHealer))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, he));
            }

                ((IHealer)healer).Heal(receiver);

            string result = string.Format(SuccessMessages.HealCharacter
            , healer.Name, receiver.Name
            , healer.AbilityPoints
            , receiver.Name, receiver.Health);


            return result;

            //"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!"
        }
    }
}

