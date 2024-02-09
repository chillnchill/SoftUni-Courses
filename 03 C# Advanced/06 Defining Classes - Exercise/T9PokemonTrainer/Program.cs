using System;
using System.Collections.Generic;
using System.Linq;

namespace T9PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> allTrainers = new List<Trainer>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Tournament")
                {
                    break;
                }
                //"{trainerName} {pokemonName} {pokemonElement} {pokemonHealth}"

                string trainerName = commands[0];
                string pokemonName = commands[1];
                string pokemonElement = commands[2];
                int pokemonHealth = int.Parse(commands[3]);

                Trainer trainer = allTrainers.SingleOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainer.Pokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                    allTrainers.Add(trainer);
                }
                else
                {
                    trainer.Pokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
                }

            }

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                foreach (var trainer in allTrainers)
                {
                    trainer.CheckPokemon(command);
                }
               
            }
            foreach (Trainer trainer in allTrainers.OrderByDescending(t=>t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemon.Count}");
            }

        }

    }
}
