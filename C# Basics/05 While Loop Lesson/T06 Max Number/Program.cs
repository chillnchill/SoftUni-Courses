using System;

namespace T06_Max_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int topNumber = int.MinValue;

            while (input != "Stop")
            {
                int nextNumber = int.Parse(input);
                input = Console.ReadLine();
                if (nextNumber > topNumber)
                {
                    topNumber = nextNumber;
                }
            }
            Console.WriteLine(topNumber);

        }
    }
}
