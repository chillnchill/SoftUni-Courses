using System;
using System.Linq;

namespace T01_Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);


            while (commands[0] != "Complete")
            {
                switch (commands[0])
                {
                    case "Make":
                        int index = int.Parse(commands[2]);
                        if (commands[1] == "Upper")
                        {
                            char sub = password[index];
                            password = password.Remove(index, 1);
                            password = password.Insert(index, sub.ToString().ToUpper());
                        }
                        else
                        {

                            char sub = password[index];
                            password = password.Remove(index, 1);
                            password = password.Insert(index, sub.ToString().ToLower());
                        }
                        Console.WriteLine(password);
                        break;
                    case "Insert":
                        int position = int.Parse(commands[1]);
                        char ch = char.Parse(commands[2]);

                        if (position >= 0 && position < password.Length)
                        {
                            password = password.Insert(position, ch.ToString());
                            Console.WriteLine(password);
                        }
                        break;
                    case "Replace":
                        char currCh = char.Parse(commands[1]);
                        int value = int.Parse(commands[2]);
                        if (password.Contains(currCh))
                        {
                            char oldChar = currCh;
                            currCh += (char)value;

                            if (password.Contains(oldChar.ToString()))
                            {
                                password = password.Replace(oldChar, currCh);
                                Console.WriteLine(password);
                            }
                        }
                        break;

                    case "Validation":

                        if (password.Length < 8)
                        {
                            Console.WriteLine("Password must be at least 8 characters long!");
                        }
                        if (!password.All(c => char.IsLetterOrDigit(c) || c.Equals('_')))
                        {
                            Console.WriteLine("Password must consist only of letters, digits and _!");
                        }
                        if (!password.Any(c => char.IsUpper(c)))
                        {
                            Console.WriteLine("Password must consist at least one uppercase letter!");
                        }
                        if (!password.Any(c => char.IsLower(c)))
                        {
                            Console.WriteLine("Password must consist at least one lowercase letter!");
                        }
                        if (!password.Any(c => char.IsDigit(c)))
                        {
                            Console.WriteLine("Password must consist at least one digit!");
                        }
                        break;

                    default:
                        commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        continue;
                }

                commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }

        }

    }
}
