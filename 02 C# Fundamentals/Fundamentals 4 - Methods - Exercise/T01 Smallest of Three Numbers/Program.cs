using System;

namespace T01_Smallest_of_Three_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());

            Console.WriteLine(FindSmallestOutOfThree(numberOne, numberTwo, numberThree));
         
        }
        private static int FindSmallestOutOfThree(int one, int two, int three) => Math.Min(one, Math.Min(two, three));
        
       
    }
}
