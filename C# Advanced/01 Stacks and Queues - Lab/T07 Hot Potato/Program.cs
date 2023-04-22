using System;
using System.Collections.Generic;

namespace T07_Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split(' ');
            int tosses = int.Parse(Console.ReadLine());
            Queue<string> childs = new Queue<string>();
            int counter = 1;

            foreach (string kid in kids)
            {
                childs.Enqueue(kid);
            }

            while (childs.Count > 1)
            {
                string currentKid = childs.Dequeue();

                if (counter == tosses)
                {
                    Console.WriteLine($"Removed {currentKid}");
                    counter = 1;
                    continue;
                }
                counter++;
                childs.Enqueue(currentKid);
            }

            Console.WriteLine($"Last is {childs.Dequeue()}");

        }
    }
}
