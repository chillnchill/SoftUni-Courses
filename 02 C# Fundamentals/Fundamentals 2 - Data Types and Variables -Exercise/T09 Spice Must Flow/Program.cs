using System;

namespace T09_Spice_Must_Flow
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int startingSpice = int.Parse(Console.ReadLine());
           int totalDaysOperating = 0;
           int spicePerDay = startingSpice;
           int totalSpiceYield = 0;

            while (spicePerDay >= 100)
            {
                totalSpiceYield += spicePerDay - 26;
                totalDaysOperating++;
                spicePerDay -= 10;

                if (spicePerDay < 100)
                {
                    totalSpiceYield -= 26;
                }
            }

            

                Console.WriteLine(totalDaysOperating);
                Console.WriteLine(totalSpiceYield);
            

           
            
        }
    }
}
