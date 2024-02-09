using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PredicateParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ').ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ');

                if (commands[0] == "Party!")
                {
                    break;
                }

                string action = commands[0];
                string filter = commands[1];
                string value = commands[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> peopleToDouble = people.FindAll(GetPredicate(filter, value));
                    int index = people.FindIndex(GetPredicate(filter, value));

                    if (index != -1)
                    {
                        people.InsertRange(index, peopleToDouble);
                    }
                }
            }
            if (people.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return s => s.StartsWith(value);
                case "EndsWith":
                    return s => s.EndsWith(value);
                case "Length":
                    return s => s.Length == int.Parse(value);
                case "Contains":
                    return s => s.Contains(value);
                default:
                    return default(Predicate<string>);

            }
        }
    }
}