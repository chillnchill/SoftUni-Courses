using System;

namespace T06_Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNumber = int.MaxValue;

            while (input != "Stop")
            {
                int nextNumber = int.Parse(input);
                input = Console.ReadLine();

                if (nextNumber < minNumber)
                {
                    minNumber = nextNumber;
                }
            }
            Console.WriteLine(minNumber);

        }
    }
}
