using System;

namespace Excellent_Result
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double currentScore = double.Parse(Console.ReadLine());
            

            if (currentScore >= 5.5)
            {
                Console.WriteLine("Excellent!");
            }
            
        }
    }
}
