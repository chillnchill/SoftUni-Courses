using System;
using System.Linq;

namespace T04_Array_Rotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sumLeft = 0;
            int sumRight = 0;

            for (int mainIndex = 0; mainIndex < numbers.Length; mainIndex++)
            {
                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }
                sumLeft = 0;
                //10 5 5 99 3 4 2 5 1 1 4
                for (int indexMovingLeft = mainIndex; indexMovingLeft > 0; indexMovingLeft--)
                {
                    int nextLeftElementPosition = indexMovingLeft - 1;
                    if (indexMovingLeft > 0)
                    {
                        sumLeft += numbers[nextLeftElementPosition];
                    }
                }

                sumRight = 0;
                //10 5 5 99 3 4 2 5 1 1 4
                for (int indexMovingRight = mainIndex; indexMovingRight < numbers.Length; indexMovingRight++)
                {
                    int nextRightElementPosition = indexMovingRight + 1;
                    if (indexMovingRight < numbers.Length - 1)
                    {
                        sumRight += numbers[nextRightElementPosition];
                    }
                }

                if (sumRight == sumLeft)
                {
                    Console.WriteLine(mainIndex);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
