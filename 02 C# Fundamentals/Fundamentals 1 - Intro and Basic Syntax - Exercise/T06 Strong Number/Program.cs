using System;

namespace T06_Strong_Number
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int singleInt = int.Parse(Console.ReadLine());
            int initalNumber = singleInt;
            
            int total = 0;
            int factorial = 1;

            while (singleInt != 0)
            {
                factorial = 1;
                int currentNum = singleInt % 10;
                singleInt = singleInt / 10;

                for (int i = currentNum; i > 0; i--)
                {
                    factorial *= i;
                    
                }
                total += factorial;
            }

                Console.WriteLine(total == initalNumber ? "yes" : "no");
            

           
        }
    }
}
