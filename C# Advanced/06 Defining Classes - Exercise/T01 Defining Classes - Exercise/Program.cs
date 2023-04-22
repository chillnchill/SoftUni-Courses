using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person firstPerson = new Person();
            

            Console.WriteLine(firstPerson.Name);
            Console.WriteLine(firstPerson.Age);

        }
    }
}
