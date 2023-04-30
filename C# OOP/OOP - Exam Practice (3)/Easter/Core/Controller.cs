using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IBunny> bunnies;
        private readonly IRepository<IEgg> eggs;

        public Controller()
        {
            bunnies = new BunnyRepository();
            eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            Bunny bunny;
            if (bunnyType == nameof(HappyBunny))
            {
                bunny = new HappyBunny(bunnyName);
            }
            else if (bunnyType == nameof(SleepyBunny))
            {
                bunny = new SleepyBunny(bunnyName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            bunnies.Add(bunny);

            return string.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);

        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);
            var bunny = bunnies.FindByName(bunnyName);

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            bunny.Dyes.Add(dye);

            return string.Format(OutputMessages.DyeAdded, power, bunnyName);

        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return string.Format(OutputMessages.EggAdded, eggName);
        }

        public string ColorEgg(string eggName)
        {
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> ableBunnies = bunnies.Models.Where(e => e.Energy >= 50).OrderByDescending(e => e.Energy).ToList();
            Workshop workshop = new Workshop();


            while (true)
            {
                if (ableBunnies.Count == 0)
                {
                    throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
                }

                foreach (IBunny bunny in ableBunnies)
                {
                    workshop.Color(egg, bunny);

                    if (bunny.Energy <= 0)
                    {
                        bunnies.Remove(bunny);
                    }
                    if (egg.IsDone())
                    {
                        break;
                    }
                }

                if (egg.IsDone())
                {
                    return string.Format(OutputMessages.EggIsDone, eggName);
                }
                else
                {
                    return string.Format(OutputMessages.EggIsNotDone, eggName);
                }

            }

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            List<IEgg> coloredEggs = eggs.Models.Where(e => e.IsDone()).ToList();
            
            result.AppendLine($"{coloredEggs.Count} eggs are done!");
            result.AppendLine("Bunnies info:");

            foreach (IBunny bunny in bunnies.Models)
            {
                result.AppendLine($"Name: {bunny.Name}");
                result.AppendLine($"Energy: {bunny.Energy}");
                result.AppendLine($"Dyes {bunny.Dyes.Count} not finished left");
            }

            return result.ToString().TrimEnd();
        }

    }
}
