using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {   //field size
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
                int initialPosition = int.Parse(cmndArgs[0]);
                string direction = cmndArgs[1];
                int movingPosition = int.Parse(cmndArgs[2]);
                //the index of the ladybug after the position has been moved
                int newLadyBugPosition = initialPosition;
                //checking if index is valid, crying, crying.
                if (initialPosition < 0 || initialPosition >= field.Length)
                {
                    continue;
                }
                //checking if initial index has a ladybug on it
                if (field[initialPosition] == 0)
                {
                    continue;
                }

                field[initialPosition] = 0;

                while (true)
                {
                    if (direction == "right")
                    {
                        newLadyBugPosition += movingPosition;
                    }
                    else
                    {
                        newLadyBugPosition -= movingPosition;
                    }
                    if (newLadyBugPosition <= 0 || newLadyBugPosition < field.Length)
                    {
                        if (field[newLadyBugPosition] == 0)
                        {
                            field[newLadyBugPosition] = 1;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }

    }
}