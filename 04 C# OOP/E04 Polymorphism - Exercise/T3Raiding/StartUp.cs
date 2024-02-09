using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3Raiding.Models;

namespace T3Raiding
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int numOfHeroes = int.Parse(Console.ReadLine());
            List<BaseHero> heroList = new List<BaseHero>();

            while (numOfHeroes > 0)
            {
                string heroName = Console.ReadLine();
                string heroClass = Console.ReadLine();
                bool isHeroValid = false;
                BaseHero hero = null;

                switch (heroClass)
                {
                    case "Druid":
                        hero = new Druid(heroName, 80);
                        isHeroValid = true;
                        break;
                    case "Paladin":
                        hero = new Paladin(heroName, 100);
                        isHeroValid = true;
                        break;
                    case "Rogue":
                        hero = new Rogue(heroName, 80);
                        isHeroValid = true;
                        break;
                    case "Warrior":
                        hero = new Warrior(heroName, 100);
                        isHeroValid = true;
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

                if (isHeroValid) 
                {
                    heroList.Add(hero);
                    numOfHeroes--;
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int powerSum = 0;

            foreach (BaseHero hero in heroList)
            {
                Console.WriteLine(hero.CastAbility()); 
                powerSum += hero.Power; 
            }

            if (powerSum >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
