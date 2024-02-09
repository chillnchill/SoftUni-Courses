using System;
using System.Collections.Generic;
using System.Linq;

namespace T10_Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> people = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, Predicate<string>> filtersToApply = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Print")
                {
                    break;
                }

                string action = commands[0];
                string filter = commands[1];
                string value = commands[2];

                if (action == "Add filter")
                {
                    filtersToApply.Add(filter + value, GetPredicate(filter, value));
                }
                else
                {
                    filtersToApply.Remove(filter + value);
                }
            }

            foreach (var filter in filtersToApply)
            {
                people.RemoveAll(filter.Value);
            }
            Console.WriteLine(String.Join(" ", people));

            
        }
        static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "Starts with":
                    return s => s.StartsWith(value);
                case "Ends with":
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
