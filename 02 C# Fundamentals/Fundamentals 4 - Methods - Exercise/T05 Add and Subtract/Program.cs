using System;

namespace T05_Add_and_Subtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int intOne = int.Parse(Console.ReadLine());
            int intTwo = int.Parse(Console.ReadLine());
            int intThree = int.Parse(Console.ReadLine());

            int add =  AddingFirstTwoIntegers(intOne, intTwo);
            int substract = SubstractingIntThreeFromAdd(add, intThree);
            Console.WriteLine(substract);
        }


        static int AddingFirstTwoIntegers(int intOne, int intTwo)
        {
            int result = intOne + intTwo;       
            return result;
        }
         static int SubstractingIntThreeFromAdd(int a, int b)
        {
            int result = a - b;
            return result;
        }
    }
}
