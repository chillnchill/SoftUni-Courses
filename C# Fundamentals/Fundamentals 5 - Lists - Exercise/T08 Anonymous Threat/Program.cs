using System;
using System.Collections.Generic;
using System.Linq;

namespace T08_Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> mainList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> commands = Console.ReadLine().Split(" ").ToList();

            while (commands[0] != "3:1")
            {
                if (commands[0] == "merge")
                {
                    int start = int.Parse(commands[1]);
                    string concatenatedPart = string.Empty;

                    if (start < 0 || start > mainList.Count - 1)
                    {
                        start = 0;
                    }
                    int end = int.Parse(commands[2]);
                    if (end > mainList.Count - 1 || end < 0)
                    {
                        end = mainList.Count - 1;
                    }
                    for (int i = start; i <= end; i++)
                    {
                        concatenatedPart += mainList[i];
                    }
                    mainList.RemoveRange(start, end - start + 1);
                    mainList.Insert(start, concatenatedPart);

                }
                else if (commands[0] == "divide")
                {
                    int start = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    List<string> dividedParts = new List<string>();
                    string toBeDivided = mainList[start];
                    mainList.RemoveAt(start);
                    int parts = toBeDivided.Length / partitions;
                    

                    for (int i = 0; i < partitions; i++)
                    {
                        //finding last part of parted string
                        if (i == partitions - 1)
                        {
                            dividedParts.Add(toBeDivided.Substring(i * parts));
                        }
                        //separating the first parts into equals
                        else
                        {
                            dividedParts.Add(toBeDivided.Substring(i * parts, parts));
                        }

                    }
                    mainList.InsertRange(start, dividedParts);
                }
                commands = Console.ReadLine().Split(" ").ToList();
            }

            Console.Write(String.Join(" ", mainList));
        }
    }
}
