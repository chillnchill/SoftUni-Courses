using System;
using System.Collections.Generic;
using System.Linq;

namespace T04_List_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "End")
            {

                switch (commands[0])
                {
                    case "Add":
                        numbers.Add(int.Parse(commands[1]));
                        break;
                    case "Insert":
                        if (int.Parse(commands[2]) > numbers.Count || int.Parse(commands[2]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.Insert(int.Parse(commands[2]), int.Parse(commands[1]));
                        break;
                    case "Remove":
                        if (int.Parse(commands[1]) > numbers.Count || int.Parse(commands[1]) < 0)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        numbers.RemoveAt(int.Parse(commands[1]));
                        break;
                    case "Shift":
                        if (commands[1] == "left")
                        {
                            int rotations = int.Parse(commands[2]);

                            for (int i = 0; i < rotations; i++)
                            {
                                numbers.Add(numbers[0]);
                                numbers.RemoveAt(0);
                            }
                        }
                        else
                        {
                            int rotations = int.Parse(commands[2]);

                            for (int i = 0; i < rotations; i++)
                            {

                                numbers.Insert(0, 0);
                                numbers[0] = numbers[numbers.Count - 1];
                                numbers.RemoveAt(numbers.Count - 1);

                            }
                        }
                        break;
                }
                commands = Console.ReadLine().Split();
            }
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
