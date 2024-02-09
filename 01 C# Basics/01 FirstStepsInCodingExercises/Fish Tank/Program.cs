using System;

namespace Fish_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int depth = int.Parse(Console.ReadLine());
            double percentTaken = double.Parse(Console.ReadLine())/100;


            double volume = length * width * depth;
            double totalLitre = volume * 0.001;
            double litreNeeded = totalLitre * (1 - percentTaken); 

            Console.WriteLine(litreNeeded);



        }
    }
}
