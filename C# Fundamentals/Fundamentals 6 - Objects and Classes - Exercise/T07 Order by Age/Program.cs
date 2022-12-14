using System;
using System.Collections.Generic;
using System.Linq;

namespace T07_Order_by_Age
{
     class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            List<Person> person = new List<Person>();

            while (input[0] != "End")
            {
                var dork = new Person()
                {
                    Name = input[0],
                    ID = int.Parse(input[1]),
                    Age = int.Parse(input[2]),
                };

                if (!person.Contains(dork))
                {
                    person.Add(dork);
                }

                input = Console.ReadLine().Split(' ');
            }

            foreach (var nerd in person.OrderBy(x => x.Age))
            {
                Console.WriteLine(nerd);
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
