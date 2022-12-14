using System;
using System.Collections.Generic;

namespace Heroes_Of_Code_And_Logic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());
            var heroHp = new Dictionary<string, int>();
            var heroMp = new Dictionary<string, int>();

            for (int i = 0; i < numOfHeroes; i++)
            {
                string[] heroStats = Console.ReadLine().Split(' ');
                string name = heroStats[0];
                int hp = int.Parse(heroStats[1]);
                int mp = int.Parse(heroStats[2]);

                if (!heroHp.ContainsKey(name))
                {
                    heroHp.Add(name, hp);
                    heroMp.Add(name, mp);
                }
            }

            string[] commands = Console.ReadLine().Split(" - ");

            while (commands[0] != "End")
            {
                string heroName = commands[1];
                switch (commands[0])
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(commands[2]);
                        string spellName = commands[3];
                        CastSpell(heroMp, heroName, mpNeeded, spellName);
                        break;

                    case "TakeDamage":
                        int damage = int.Parse(commands[2]);
                        string attacker = commands[3];
                        TakeDamage(heroHp, heroMp, heroName, damage, attacker);
                        break;

                    case "Recharge":
                        int mp = int.Parse(commands[2]);
                        RechargeMana(heroMp, heroName, mp);
                        break;

                    case "Heal":
                        int hp = int.Parse(commands[2]);
                        Heal(heroHp, heroName, hp);
                        break;

                }
                commands = Console.ReadLine().Split(" - ");
            }
           foreach (var name in heroHp)
            {
                int mana = heroMp[name.Key];
                Console.WriteLine(name.Key);
                Console.WriteLine($"  HP: {name.Value}");
                Console.WriteLine($"  MP: {mana}");
            }
        }

        static void CastSpell(Dictionary<string, int> heroMp, string heroName, int mpNeeded, string spellName)
        {
            int currentMp = heroMp[heroName];
            if (currentMp >= mpNeeded)
            {
                heroMp[heroName] -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroMp[heroName]} MP!");

            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }
        static void TakeDamage(Dictionary<string, int> heroHp, Dictionary<string, int> heroMp, string heroName, int damage, string attacker)
        {
            int currentHP = heroHp[heroName];
            if (currentHP > damage)
            {
                heroHp[heroName] -= damage;
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroHp[heroName]} HP left!");
            }
            else
            {
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
                heroHp.Remove(heroName);
                heroMp.Remove(heroName);
            }
            
        }

        static void RechargeMana(Dictionary<string, int> heroMp, string heroName, int mp)
        {
            int max = 200;
            int currentMp = heroMp[heroName];
            heroMp[heroName] += mp;
            if (heroMp[heroName] > max)
            {
                mp -= (currentMp + mp) - 200;
                heroMp[heroName] = max;
            }
            Console.WriteLine($"{heroName} recharged for {mp} MP!");
        }

        static void Heal(Dictionary<string, int> heroHp, string heroName, int hp)
        {
            int max = 100;
            int currentHp = heroHp[heroName];
            heroHp[heroName] += hp;
            if (heroHp[heroName] > max)
            {
                hp -= (currentHp + hp) - 100;
                heroHp[heroName] = max;
            }
            Console.WriteLine($"{heroName} healed for {hp} HP!");
        }
    }
}
