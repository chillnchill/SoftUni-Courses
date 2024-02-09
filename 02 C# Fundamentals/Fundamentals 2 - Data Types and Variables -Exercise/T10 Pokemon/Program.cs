using System;

namespace T10_Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingPokePower = int.Parse(Console.ReadLine());
            int distanceBetweenTargets = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int pokemonsPoked = 0;
            int currentPower = startingPokePower;

            while (currentPower >= distanceBetweenTargets)
            {
                currentPower -= distanceBetweenTargets;
                pokemonsPoked++;

                if (startingPokePower / 2 == currentPower && exhaustion > 0)
                {
                   currentPower /= exhaustion;
                }

            }

            Console.WriteLine(currentPower);
            Console.WriteLine(pokemonsPoked);

        }
    }
}