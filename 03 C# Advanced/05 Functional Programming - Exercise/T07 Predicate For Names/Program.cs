using System;
using System.Collections.Generic;
using System.Linq;

namespace T07_Predicate_For_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int filter = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ").ToList();


            Action<List<string>, Predicate<string>> removeFiltered = (names, match) =>
            {
                foreach (string name in names)
                {
                    if (match(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            removeFiltered(names, n => n.Length <= filter);

        }
    }
}
