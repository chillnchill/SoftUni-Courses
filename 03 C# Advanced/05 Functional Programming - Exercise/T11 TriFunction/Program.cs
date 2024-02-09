using System;
using System.Linq;

namespace T11_TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int soughtNumber = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Func<string, int, bool> initialChecks = (name, sum) =>
            name.Sum(ch => ch) >= sum;

            Func<string[], int, Func<string, int, bool>, string> firstName = (name, sum, firstMatch) =>
            name.FirstOrDefault(name => firstMatch(name, sum));

            Console.WriteLine(firstName(names, soughtNumber, initialChecks));


            
        }
    }
}
