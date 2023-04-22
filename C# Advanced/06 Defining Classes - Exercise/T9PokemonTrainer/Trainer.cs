using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T9PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemon = new List<Pokemon>();
        }

        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemon { get; set; }

        public void CheckPokemon(string element)
        {
            if (this.Pokemon.Any(p => p.Element == element))
            {
                NumberOfBadges++;
            }
            else
            {
                for (int i = 0; i < this.Pokemon.Count; i++)
                {
                    Pokemon currentPokemon = this.Pokemon[i];

                    currentPokemon.Health -= 10;

                    if (currentPokemon.Health <= 0)
                    {
                        this.Pokemon.Remove(currentPokemon);
                    }
                }
            }
        }
    }
}
