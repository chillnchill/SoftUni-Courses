using System;

namespace T03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            string typeOfGrp = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double total = 0;

            if (typeOfGrp == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    total = numberOfPeople * 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    total = numberOfPeople * 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    total = numberOfPeople * 10.46;
                }
                if (numberOfPeople >= 30)
                {
                    total -= total * 0.15;
                }
            }

            else if (typeOfGrp == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    total = numberOfPeople * 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    total = numberOfPeople * 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    total = numberOfPeople * 16;
                }
                if (numberOfPeople >= 100)
                {
                    total -= total / numberOfPeople * 10;
                }
            }
            else if (typeOfGrp == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    total = numberOfPeople * 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    total = numberOfPeople * 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    total = numberOfPeople * 22.50;
                }
                if (numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    total -= total * 0.05;
                }
            }



                 Console.WriteLine($"Total price: {total:f2}");
        }
    }
}
