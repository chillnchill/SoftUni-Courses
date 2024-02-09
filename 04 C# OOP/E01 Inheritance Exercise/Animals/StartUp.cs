using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (true)
            {
                if (input == "Beast!")
                {
                    break;
                }

                string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = commands[0];
                int age = int.Parse(commands[1]);

                if (age < 0)
                {
                    Console.WriteLine("Invalid input!");
                }

                Animal animal = default;

                if (input == "Cat")
                {
                    animal = new Cat(name, age, commands[2]);
                }
                else if (input == "Dog")
                {
                    animal = new Dog(name, age, commands[2]);
                }
                else if (input == "Frog")
                {
                    animal = new Frog(name, age, commands[2]);
                }
                else if (input == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else if (input == "Tomcat")
                {
                    animal = new Tomcat(name, age);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                Console.WriteLine(animal.ToString());
                input = Console.ReadLine();
            }
        }
    }
}
