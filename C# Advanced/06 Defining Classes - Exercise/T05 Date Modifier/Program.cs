using System;

namespace T05DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startingDate = Console.ReadLine();
            string endingDate = Console.ReadLine();
            Console.WriteLine(DateModifier.DaysDifference(startingDate, endingDate));   
        }
    }
}
