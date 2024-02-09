using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            List<string> people = new List<string>();

            for (int i = 0; i < numOfPeople; i++)
            {
                string[] peopleInfo = Console.ReadLine().Split(' ');
                string name = peopleInfo[0];
                int age = int.Parse(peopleInfo[1]);
                Person person = new Person(name, age);

                if (person.Age >= 30)
                {
                    people.Add($"{person.Name} - {person.Age}");
                }
                
            }

            people.Sort();

            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}
