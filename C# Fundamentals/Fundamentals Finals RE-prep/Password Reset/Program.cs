using System;

namespace Password_Reset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();           
            string[] commands = Console.ReadLine().Split(' ');

            while (commands[0] != "Done")
            {
                switch (commands[0])
                {
                    case "TakeOdd":
                        string newPass = "";
                        for (int i = 1; i < password.Length; i++)
                        {
                            if (i % 2 != 0)
                            {
                                newPass += password[i];
                            }
                        }
                        password = newPass;
                        Console.WriteLine(password);
                            break;
                    case "Cut":
                        int index = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);
                        string sub = password.Substring(index, length);
                        int indexOf = password.IndexOf(sub);
                        password = password.Remove(indexOf, sub.Length);
                        Console.WriteLine(password);
                        break;
                    case "Substitute":
                        string contained = commands[1];
                        string toBeSubbed = commands[2];
                        
                        if (password.Contains(contained))
                        {
                            password = password.Replace(contained, toBeSubbed);
                            Console.WriteLine(password);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(' ');
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}
