using System;
using System.Linq;

namespace T001_another_demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int sumRight = 0;
            int sumLeft = 0;

            //10 5 5 99 3 4 2 5 1 1 4
            for (int i = 0; i < array.Length; i++)
            {

                if (array.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                sumRight = 0;

                for (int goingRight = 0; goingRight < i; goingRight++)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    sumRight += array[goingRight];
                }

                sumLeft = 0;

                for (int goingleft = array.Length - 1; goingleft > i; goingleft--)
                {
                    if (i != array.Length - 1)
                    {
                        sumLeft += array[goingleft];
                    }
                }
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(i);
                    return;
                }
            }

            Console.WriteLine("no");
        }
    }
}

