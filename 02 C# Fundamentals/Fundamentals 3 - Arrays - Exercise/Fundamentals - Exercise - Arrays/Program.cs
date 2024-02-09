using System;

namespace Fundamentals___Exercise___Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] peopleInTrain = new int[n];
            int sum = 0;

            for (int i = 0; i < n; i++)

            {
                peopleInTrain[i] = int.Parse(Console.ReadLine());
                sum += peopleInTrain[i];

            }

            foreach (int i in peopleInTrain)
            {
                Console.Write($"{i} ");
            }

            Console.WriteLine();
            Console.WriteLine(sum);
        } 
    }
}
