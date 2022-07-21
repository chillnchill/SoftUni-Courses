using System;

namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write is writes on the same line, Console.WriteLine writes and puts us on a new line
            Console.Write("Blabla");
            Console.WriteLine("Hello World!");
            Console.Write("HelloSoftUni");

            //here the normal brackets play the same role they do in math, prioritising the action
            int numberInRange = 5 + 9 * (0 + 2);
            //double is for fractional numbers
            double num2 = 55.5;
            //the computer will read this number as text, not something it can do arithmetics with
            string str = "5";


        }

    }
}
