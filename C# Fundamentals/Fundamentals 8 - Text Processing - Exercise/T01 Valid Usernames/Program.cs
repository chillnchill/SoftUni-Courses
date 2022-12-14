using System;
using System.Collections.Generic;

namespace T01_Valid_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");
            string validUserName = "";
            List<string> allValid = new List<string>();
            
            foreach (string name in userNames)
            {
                if (name.Length >= 3 && name.Length <= 16)
                {
                    foreach (char c in name)
                    {
                        if (char.IsLetterOrDigit(c) || c == '-' || c == '_')
                        {
                            validUserName += c;
                        }
                        else
                        {
                            validUserName = "";
                            break;
                        }

                    }
                    allValid.Add(validUserName);
                    validUserName = "";
                }
                
            }
           
            foreach (string name in allValid)
            {
                if (name != "")
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}
