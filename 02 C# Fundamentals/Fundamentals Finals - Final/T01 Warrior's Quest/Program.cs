using System;

namespace T01_Warrior_s_Quest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string skill = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (string.Join(" ", commands) != "For Azeroth")
            {
                switch (commands[0])
                {
                    case "GladiatorStance":
                        skill = skill.ToUpper();
                        Console.WriteLine(skill);
                        break;
                    case "DefensiveStance":
                        skill = skill.ToLower();
                        Console.WriteLine(skill);
                        break;
                    case "Dispel":
                        int index = int.Parse(commands[1]);
                        string letter = commands[2];
                        if (index >= 0 && index < skill.Length)
                        {
                            skill = skill.Remove(index, 1);
                            skill = skill.Insert(index, letter);
                            Console.WriteLine("Success!");
                        }
                        else
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;
                    case "Target":
                        string action = commands[1];
                        if (action != "Remove" && action != "Change")
                        {
                            Console.WriteLine("Command doesn't exist!");
                            break;
                        }
                            if (action == "Change") 
                        {
                            string firstSub = commands[2];
                            string secondSub = commands[3];
                            if (skill.Contains(firstSub))
                            {
                                skill = skill.Replace(firstSub, secondSub);
                                Console.WriteLine(skill);
                                break;

                            }
                            Console.WriteLine(skill);
                          
                        }
                        if (action == "Remove")
                        {
                            string sub = commands[2];
                            int indexOfSub = skill.IndexOf(sub);
                            if (skill.Contains(sub))
                            {
                                skill = skill.Remove(indexOfSub, sub.Length);
                                Console.WriteLine(skill);                              
                            }
                        }

                        
                        break;
                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;

                }


                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }
}
