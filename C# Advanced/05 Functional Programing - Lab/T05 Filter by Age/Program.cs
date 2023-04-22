using System;
using System.Collections.Generic;
using System.Linq;

namespace T05_Filter_by_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> listOfPeople = new List<Person>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] info = Console.ReadLine().Split(", ");
                string name = info[0];
                int age = int.Parse(info[1]);
                var person = new Person();
                person.Name = name;
                person.Age = age;
                listOfPeople.Add(person);
            }
            string filterName = Console.ReadLine();
            int specificAge = int.Parse(Console.ReadLine());


            Func<Person, bool> filter = p => true;

            if (filterName == "younger")
            {
                filter = p => p.Age < specificAge;
            }
            else if (filterName == "older")
            {
                filter = p => p.Age >= specificAge;
            }

            var filteredPeople = listOfPeople.Where(filter);
            string whatToPrint = Console.ReadLine();
            foreach (var person in filteredPeople)
            {
                if (whatToPrint == "name")
                {
                    Console.WriteLine(person.Name);
                }
                else if (whatToPrint == "age")
                {
                    Console.WriteLine(person.Age);
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }
        }

    }

    class Person
    {
        public string Name;

        public int Age;
    }
}
