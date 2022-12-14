using System;

namespace T02_Articles
{
     class Program
    {
        static void Main(string[] args)
        {
            string[] mainArticle = Console.ReadLine().Split(", ");
            int numberOfChanges = int.Parse(Console.ReadLine());
            var article = new Article(mainArticle[0], mainArticle[1], mainArticle[2]);

            for (int i = 0; i < numberOfChanges; i++)
            {
                string[] commands = Console.ReadLine().Split(": ");

                switch (commands[0])
                {
                    case "Edit":
                        article.Content = commands[1];
                        break;
                    case "ChangeAuthor":
                        article.Author = commands[1];
                        break;
                    case "Rename":
                        article.Title = commands[1];
                        break;
                }
            }
            Console.WriteLine(article);
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
        public string Author  { get; set; }

        public void ChangeTitle(string title) => Title = title;
        public void ChangeContent(string content) => Content = content;
        public void ChangeAuthor(string author) => Author = author;

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
