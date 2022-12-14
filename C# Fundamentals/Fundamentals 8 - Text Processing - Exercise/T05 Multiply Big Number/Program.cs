using System;
using System.Text;

namespace T05_Multiply_Big_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ratherLargeNum = Console.ReadLine();
            int toBeMultiplied = int.Parse(Console.ReadLine());
            int temporary = 0;
            int result = 0;

            StringBuilder building = new StringBuilder(); 

            if (toBeMultiplied == 0)
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = ratherLargeNum.Length-1; i >= 0; i--)
            {
                char currentChar = ratherLargeNum[i];
                int currentNum = int.Parse(currentChar.ToString());
                result = currentNum * toBeMultiplied + temporary; 
                
                
                building.Append(result % 10);
                temporary = result / 10;

            }
            if (temporary != 0)
            {
                building.Append(temporary);
            }


            StringBuilder reversedBuilding = new StringBuilder();

            for (int i = building.Length - 1; i >= 0; i--)
            {
                reversedBuilding.Append(building[i]);
            }
            Console.WriteLine(reversedBuilding);
        }
    }
}
