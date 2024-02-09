using System;

namespace T06_Middle_Characters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            
            FindMiddleCharacter(initial);
            
        }
        private static void FindMiddleCharacter(string initial)
        {
            int halfWay = 0;

            if (initial.Length % 2 != 0)
            {
                halfWay = initial.Length / 2;
                Console.WriteLine(initial[halfWay]);
            }
            else if (initial.Length % 2 == 0)
            {
                halfWay = initial.Length / 2;
                Console.WriteLine($"{initial[halfWay - 1]}{initial[halfWay]}");
            }
        }
    }
}
