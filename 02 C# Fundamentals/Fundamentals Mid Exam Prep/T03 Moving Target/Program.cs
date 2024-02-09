using System;
using System.Collections.Generic;
using System.Linq;

namespace T03_Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<string> commands = Console.ReadLine().Split(" ").ToList();

            while (commands[0] != "End")
            {
                int index = int.Parse(commands[1]);

                switch (commands[0])
                {
                    case "Shoot":
                        
                        int power = int.Parse(commands[2]);

                        if (index >= 0 && index < targets.Count)
                        {
                            targets[index] -= power;
                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;
                    case "Add":
                        int value = int.Parse(commands[2]);
                        if (index >= 0 && index < targets.Count)
                        {
                            targets.Insert(index, value);
                        }
                        else
                        {
                            Console.WriteLine("Invalid placement!");
                        }
                        break;
                    case "Strike":
                        int radius = int.Parse(commands[2]);

                        if (index < 0 || index > targets.Count - 1)
                        {
                            Console.WriteLine("Strike missed!");
                            break;
                        }
                        else if (index + radius > targets.Count -1 || index - radius < 0)
                        {
                            Console.WriteLine("Strike missed!");
                            break;
                        }
                        else
                        {
                            int count = (radius * 2) + 1;
                            targets.RemoveRange(index - radius, count);
                            if (radius == 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }

                        break;
                }
                
                commands = Console.ReadLine().Split(" ").ToList();
                        
            
            
            }

            Console.WriteLine(String.Join("|", targets));

        
        }
    }
}
