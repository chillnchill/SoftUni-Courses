using System;
using System.Linq;

namespace T10_Top_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            IsTopNumber(number);

        }

        private static void IsTopNumber(int number)
        {
            int current = 0;
            int total = 0;

            for (int i = 17; i < number; i++)
            {
                bool isThereOddNumber = false;
                int currentNum = i;

                while (currentNum > 0)
                {
                    current = currentNum % 10;
                    total += current;

                    if (current % 2 != 0)
                    {
                        isThereOddNumber = true;
                    }
                    currentNum /= 10;
                }
                if (total % 8 == 0 && isThereOddNumber == true)
                {
                    Console.WriteLine(i);
                }
                isThereOddNumber = false;
                total = 0;
            }
        }
    }
}
