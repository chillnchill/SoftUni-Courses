using System;

namespace T07_String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string toBeBlown = Console.ReadLine();
            int boomPower = 0;

            for (int i = 0; i < toBeBlown.Length; i++)
            {
                if (toBeBlown[i] == '>')
                {
                    boomPower += int.Parse(toBeBlown[i + 1].ToString());
                }
                else if (boomPower != 0 && toBeBlown[i] != '>')
                {
                    toBeBlown = toBeBlown.Remove(i, 1);
                    boomPower--;
                    i--;
                }
            }
            Console.WriteLine(toBeBlown);
        }
    }
}
