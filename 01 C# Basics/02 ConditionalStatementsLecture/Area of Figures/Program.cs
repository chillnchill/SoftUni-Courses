using System;

namespace Area_of_Figures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();

            double result = 0;

            if (figure == "square")
            {
                double sides = double.Parse(Console.ReadLine());
                 result = sides * sides;

            }
            else if (figure == "rectangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                 result = side1 * side2;
                
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                 result = Math.PI * (radius * radius);
               
            }
            else if (figure == "triangle")
            {
                double side1 = double.Parse(Console.ReadLine());
                double side2 = double.Parse(Console.ReadLine());
                 result = (side1 * side2) / 2;
                
            }
            if (result > 0)
            {
                Console.WriteLine($"{result:f3}");
            }
            
        }
    }
}
