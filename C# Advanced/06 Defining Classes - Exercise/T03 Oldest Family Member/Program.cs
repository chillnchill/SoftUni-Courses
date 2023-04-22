using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfppl = int.Parse(Console.ReadLine());
            Family family = new Family();


            for (int i = 0; i < numOfppl; i++)
            {
                string[] peopleStats = Console.ReadLine().Split(' ');               
                string name = peopleStats[0];
                int age = int.Parse(peopleStats[1]);

                Person person = new Person(name, age);
               
                family.AddMember(person);
            }
            Person dork = family.GetOldestMember();
            Console.WriteLine($"{dork.Name} {dork.Age}");
            
        }
    }
}
