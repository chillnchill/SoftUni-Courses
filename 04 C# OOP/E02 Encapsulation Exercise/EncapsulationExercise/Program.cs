using System;
using System.Collections.Generic;
using System.Linq;

namespace EncapsulationExercise
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>(); 
            List<Product> productList = new List<Product>();

            try
            {
                string[] personInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string personMoneyPair in personInput)
                {
                    string[] splitPair = personMoneyPair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(splitPair[0], decimal.Parse(splitPair[1]));
                    personList.Add(person);
                }

                string[] productInput = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string productCostPair in productInput)
                {
                    string[] splitPair = productCostPair.Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(splitPair[0], decimal.Parse(splitPair[1]));
                    productList.Add(product);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }




            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] personProduct = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string personName = personProduct[0];
                string productName = personProduct[1];

                Person person = personList.FirstOrDefault(p => p.Name == personName);
                Product product = productList.FirstOrDefault(p => p.Name == productName);

                if (person != null && product != null)
                {
                    Console.WriteLine(person.AddProduct(product));
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, personList));

        }
    }
}
