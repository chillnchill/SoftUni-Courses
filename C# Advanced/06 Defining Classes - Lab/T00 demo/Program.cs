using System;

namespace Dice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.ReadLine();
                Dice dice = ThrowDice();
                Console.WriteLine($"You threw {dice.Side}");
            }

        }
    }
}
