using System;

namespace T03_Sum_Prime_Non_Prime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            int sumPrime = 0;
            int sumOther = 0;

            while (n != "stop")
            {
                int number = int.Parse(n);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    n = Console.ReadLine();
                    continue;
                }

                bool isPrime = true;

                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    sumPrime += number;
                }
                else
                {
                    sumOther += number;
                }
                n = Console.ReadLine();
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrime}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumOther}");


        }
    }
}
