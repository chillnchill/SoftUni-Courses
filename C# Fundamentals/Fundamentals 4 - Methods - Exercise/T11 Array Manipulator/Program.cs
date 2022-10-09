using System;
using System.Collections.Generic;
using System.Linq;

namespace T11_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "end")
            {
                if (commands[0] == "exchange")
                {
                    array = ExchangeArrayCommand(commands, array);
                }
                else if (commands[0] == "max" || commands[0] == "min")
                {
                    FindMaxAndMinOddOrEvenNumbers(array, commands[0], commands[1]);
                }
                else
                {
                    FindEvenOddNumbersByIndex(array, commands[0], int.Parse(commands[1]), commands[2]);
                }
                commands = Console.ReadLine().Split();
            }

            Console.WriteLine($"[{String.Join(", ", array)}]");

        }
        private static void FindEvenOddNumbersByIndex(int[] array, string direction, int number, string evenOrOdd)
        {
            if (number > array.Length)
            {
                Console.WriteLine("Invalid count");
                return;
            }
            if (number == 0)
            {
                Console.WriteLine($"[]");
                return;
            }

            //target to know when the desired number count is reached
            int target = 0;
            int evenOroddNumber = 1;
            List<int> nums = new List<int>();

            if (evenOrOdd == "even") evenOroddNumber = 0;

            if (direction == "first")
            {
                foreach (int currentNum in array)
                {
                    if (currentNum % 2 == evenOroddNumber)
                    {
                        target++;
                        nums.Add(currentNum);
                    }
                    if (target == number) break;
                }
            }
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if (array[i] % 2 == evenOroddNumber)
                    {
                        target++;
                        nums.Add(array[i]);
                    }
                    if (target == number) break;
                }
                nums.Reverse();
            }
            Console.WriteLine($"[{String.Join(", ", nums)}]");
        }

        private static void FindMaxAndMinOddOrEvenNumbers(int[] array, string minOrMax, string evenOrOdd)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int evenOrOddNum = 1;
            int index = -1;

            if (evenOrOdd == "even") evenOrOddNum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == evenOrOddNum)
                {
                    if (minOrMax == "min" && min >= array[i])
                    {
                        min = array[i];
                        index = i;
                    }
                    else if (minOrMax == "max" && max <= array[i])
                    {
                        max = array[i];
                        index = i;
                    }
                }
            }
            Console.WriteLine(index > -1 ? index.ToString() : "No matches");
        }

        private static int[] ExchangeArrayCommand(string[] commands, int[] array)
        {
            int exchangeIndex = int.Parse(commands[1]);

            if (exchangeIndex >= array.Length || exchangeIndex < 0)
            {
                Console.WriteLine("Invalid index");
                return array;
            }

            int[] exchangedArray = new int[array.Length];
            int counter = 0;

            for (int i = exchangeIndex + 1; i < array.Length; i++)
            {
                exchangedArray[counter] = array[i];
                counter++;
            }

            for (int i = 0; i <= exchangeIndex; i++)
            {
                exchangedArray[counter] = array[i];
                counter++;
            }
            return exchangedArray;
        }
    }
}

