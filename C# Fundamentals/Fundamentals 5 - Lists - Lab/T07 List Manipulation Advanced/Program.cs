using System;
using System.Collections.Generic;
using System.Linq;

namespace T06_List_Manipulation_Basics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> initial = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            string commands;
            bool didInitialGetModified = false;

            while ((commands = Console.ReadLine()) != "end")
            {
                string[] commandsParsed = commands.Split();

                switch (commandsParsed[0])
                {
                    case "Add":

                        initial.Add(int.Parse(commandsParsed[1]));
                        didInitialGetModified = true;
                        break;

                    case "Remove":
                        initial.Remove(int.Parse(commandsParsed[1]));
                        didInitialGetModified = true;
                        break;

                    case "RemoveAt":
                        initial.RemoveAt(int.Parse(commandsParsed[1]));
                        didInitialGetModified = true;
                        break;

                    case "Insert":
                        initial.Insert(int.Parse(commandsParsed[2]), int.Parse(commandsParsed[1]));
                        didInitialGetModified = true;
                        break;

                    case "Contains":
                        DoesListContainNumber(initial, commandsParsed[1]);
                        break;

                    case "PrintEven":

                        Console.WriteLine(String.Join(" ", initial
                            .Where(number => number % 2 == 0)));
                        break;

                    case "PrintOdd":

                        Console.WriteLine(String.Join(" ", initial
                            .Where(number => number % 2 != 0)));
                        break;

                    case "GetSum":

                        Console.WriteLine(initial.Sum());
                        break;

                    case "Filter":

                        FilterItemsViaSymbol(initial, commandsParsed[1], int.Parse(commandsParsed[2]));

                        break;

                }
            }

            if (didInitialGetModified == true)
            {
                Console.WriteLine(String.Join(" ", initial));
            }

            
        }

        private static void FilterItemsViaSymbol(List<int> initial, string symbol, int number)
        {
            switch (symbol)
            {
                case "<":
                    Console.WriteLine(String.Join(" ", initial
                        .Where(n => n < number)));
                    break;

                case ">":
                    Console.WriteLine(String.Join(" ", initial
                        .Where(n => n > number)));
                    break;

                case ">=":
                    Console.WriteLine(String.Join(" ", initial
                        .Where(n => n >= number)));
                    break;

                case "<=":
                    Console.WriteLine(String.Join(" ", initial
                        .Where(n => n <= number)));
                    break;
            }
        }

        private static void DoesListContainNumber(List<int> initial, string commandsParsed)
        {
            if (initial.Contains(int.Parse(commandsParsed)))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No such number");
            }

        }

    }
}
