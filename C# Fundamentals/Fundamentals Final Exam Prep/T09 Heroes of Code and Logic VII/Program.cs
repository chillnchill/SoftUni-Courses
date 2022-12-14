using System;
using System.Collections.Generic;

namespace T09_Heroes_of_Code_and_Logic_VII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfHeroes = int.Parse(Console.ReadLine());
            var allHeroes = new List<string>();
            var heroStats = new Dictionary<string, KeyValuePair<int, int>>();

            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] hero = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = hero[0];
                int hp = int.Parse(hero[1]);
                int mp = int.Parse(hero[2]);

                if (!heroStats.ContainsKey(name))
                {
                    heroStats.Add(name, new KeyValuePair<int, int>(hp, mp));
                    allHeroes.Add(hero[0]);
                }

            }

            string[] commands = Console.ReadLine().Split(" - ");

            while (commands[0] != "End")
            {
                string heroName = commands[1];
                var hp = heroStats[heroName].Key;
                var mp = heroStats[heroName].Value;


                switch (commands[0])
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        if (mp >= mpNeeded)
                        {
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {mp - mpNeeded} MP!");
                            heroStats[heroName] = new KeyValuePair<int, int>(hp, mp - mpNeeded);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        if (hp > damage)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hp - damage} HP left!");
                            heroStats[heroName] = new KeyValuePair<int, int>(hp - damage, mp);
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroStats.Remove(heroName);
                            allHeroes.Remove(heroName);

                        }
                        break;
                    case "Recharge":
                        int recharge = int.Parse(commands[2]);
                        mp += recharge;
                        if (mp > 200)
                        {
                            int overcharge = mp - 200;
                            recharge -= overcharge;
                            mp = 200;
                        }
                        Console.WriteLine($"{heroName} recharged for {recharge} MP!");
                        heroStats[heroName] = new KeyValuePair<int, int>(hp, mp);
                        break;
                    case "Heal":
                        int heal = int.Parse(commands[2]);
                        hp += heal;
                        if (hp > 100)
                        {
                            int overheal = hp - 100;
                            heal -= overheal;
                            hp = 100;
                        }
                        Console.WriteLine($"{heroName} healed for {heal} HP!");
                        heroStats[heroName] = new KeyValuePair<int, int>(hp, mp);
                        break;
                }
                commands = Console.ReadLine().Split(" - ");
            }
            foreach (var hero in allHeroes)
            {
                Console.WriteLine(hero);
                Console.WriteLine($"  HP: {heroStats[hero].Key}");
                Console.WriteLine($"  MP: {heroStats[hero].Value}");
            }
        }
    }
}
