using System;
using System.Collections.Generic;

namespace T02_Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();
            
            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] initial = Console.ReadLine().Split(", ");
                var piece = new Article(initial[0], initial[1], initial[2]); 
                articles.Add(piece);
                
            }
            string stringer = Console.ReadLine();

            foreach (var article in articles)
            {
                Console.WriteLine(article);
            }           
        }
    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;

        }

        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
