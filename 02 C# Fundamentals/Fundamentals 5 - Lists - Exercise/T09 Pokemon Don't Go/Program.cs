using System;
using System.Collections.Generic;
using System.Linq;

namespace T09_Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemon = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sum = 0;

            while (pokemon.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index < 0)
                {
                    index = 1;
                    pokemon.Insert(0, pokemon[pokemon.Count - 1]);                   
                }
                else if (index > pokemon.Count - 1)
                {
                    index = pokemon.Count-1;                   
                    pokemon.Add(pokemon[0]);
                }


                    for (int i = 0; i < pokemon.Count; i++)
                    {
                        if (i == index)
                        {
                            continue;
                        }
                        else if (pokemon[index] < pokemon[i])
                        {
                            pokemon[i] -= pokemon[index];
                        }
                        else if (pokemon[index] >= pokemon[i])
                        {
                            pokemon[i] += pokemon[index];
                        }
                    }
                

                sum += pokemon[index];
                pokemon.RemoveAt(index);
            }

            Console.WriteLine(sum);
        }
    }
}
