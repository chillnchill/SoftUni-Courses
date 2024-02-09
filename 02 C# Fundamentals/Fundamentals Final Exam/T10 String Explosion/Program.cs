using System;

namespace T10_String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosionPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    explosionPower += int.Parse(input[i].ToString());
                }
                if (char.IsLetterOrDigit(input[i]) && explosionPower != 0)
                {
                    input = input.Remove(i, 1);
                    explosionPower--;
                    i--;
                }
            }
            Console.WriteLine(input);
        }
    }
}
