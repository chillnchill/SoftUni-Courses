using System;

namespace T01_Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfReviews = int.Parse(Console.ReadLine());

            string[] phrases = { "Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.", "Exceptional product.", "I can't live without this product." };

            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };

            string[] author = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] city = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random random = new Random();


            for (int i = 0; i < numberOfReviews; i++)
            {

                int rndPhrase = random.Next(0, phrases.Length);
                int rndEvent = random.Next(0, events.Length);
                int rndAuthor = random.Next(0, author.Length);
                int rndCity = random.Next(0, city.Length);

                Console.WriteLine($"{phrases[rndPhrase]} {events[rndEvent]} {author[rndAuthor]} - {city[rndCity]}");
            }

        }

}
}




