using System;
using System.Linq;

namespace T10_Lady_bugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            //lady bugs on the field
            int[] ladyBugPositions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            //the field where lady bugs bug and await debugging
            int[] field = new int[n];


            //creating the field
            for (int index = 0; index < n; index++)
            {
                if (ladyBugPositions.Contains(index))
                {
                    //if the index is 'present' in ladyBugPositions then there will be a 1 in the playing field
                    field[index] = 1;
                }
            }
            String.Join(" ", field);
            //string to help us spinny spin the while cycle
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] cmndArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int initialIndex = int.Parse(cmndArgs[0]);
                string direction = cmndArgs[1];
                int flyLength = int.Parse(cmndArgs[2]);
                //the index of the ladybug after the position has been moved
                
                //checking if index is valid, crying, crying.
                if (initialIndex < 0 || initialIndex >= field.Length)
                {
                    continue;
                }
                //checking if the first initialIndex has a ladybug on it to initialize our rotation
                if (field[initialIndex] == 0)
                {
                    continue;
                }

                field[initialIndex] = 0;

                int nextIndex = initialIndex;


                while (true)
                {
                    if (direction == "right")
                    {
                        nextIndex += flyLength;
                    }
                    else if (direction == "left")
                    {
                        nextIndex -= flyLength;
                    }

                    if (nextIndex < 0 || nextIndex >= field.Length)
                    {
                        break;
                    }

                    if (field[nextIndex] == 0)
                    {
                        break;
                    }
                }
                if (nextIndex >= 0 && nextIndex < field.Length)
                {
                    field[nextIndex] = 1;
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
