namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private TextBook textBook;
        private string author = "J.K Bolwing";
        private string title = "Harry Slotter";
        private string category = "Friction";
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title, author, category);
        }

        [Test]
        public void Test_DoesTextBookConstruct_Work()
        {
            Assert.AreEqual(author, textBook.Author);
            Assert.AreEqual(category, textBook.Category);
            Assert.AreEqual(title, textBook.Title);
        }

        [Test]
        public void Test_DoesTheLibrary_Work()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook leisureBook = new TextBook("Harry Slotter", "J.K Bolwing", "Friction");
            TextBook textBook = new TextBook("C# complicated", "Uncle Bob", "Computer Science");
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.AreEqual("Harry Slotter", leisureBook.Title);
            Assert.AreEqual("J.K Bolwing", leisureBook.Author);


            library.AddTextBookToLibrary(leisureBook);
            library.AddTextBookToLibrary(textBook);

            Assert.AreEqual(1, leisureBook.InventoryNumber);
            Assert.AreEqual(2, textBook.InventoryNumber);

            leisureBook.Holder = "Stoqn";
            Assert.AreEqual("Stoqn", leisureBook.Holder);
            leisureBook.Holder = "";
            Assert.AreEqual("", leisureBook.Holder);
            leisureBook.Holder = null;
            Assert.AreEqual(null, leisureBook.Holder);

            Assert.AreEqual(2, library.Catalogue.Count);
            Assert.AreEqual("Book: Harry Slotter - 1\r\nCategory: Friction\r\nAuthor: J.K Bolwing", leisureBook.ToString());

        }

        [Test]
        public void Test_DoesLoanTextBook_Work()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook leisureBook = new TextBook("Harry Slotter", "J.K Bolwing", "Friction");
            TextBook textBook = new TextBook("C# complicated", "Uncle Bob", "Computer Science");
            library.AddTextBookToLibrary(leisureBook);
            library.AddTextBookToLibrary(textBook);
            leisureBook.Holder = "Stoqn";
            textBook.Holder = "Andrey";

            Assert.AreEqual("Stoqn still hasn't returned Harry Slotter!", library.LoanTextBook(1, "Stoqn"));
            Assert.AreEqual("Andrey still hasn't returned C# complicated!", library.LoanTextBook(2, "Andrey"));

            textBook.Holder = "";
            Assert.AreEqual("C# complicated loaned to Sandoci.", library.LoanTextBook(2, "Sandoci"));
            Assert.AreEqual("Sandoci", textBook.Holder);

            textBook.Holder = null;
            Assert.AreEqual("C# complicated loaned to Sandoci.", library.LoanTextBook(2, "Sandoci"));

        }


        [Test]
        public void Test_DoesReturnTextBook_Work()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook leisureBook = new TextBook("Harry Slotter", "J.K Bolwing", "Friction");
            TextBook textBook = new TextBook("C# complicated", "Uncle Bob", "Computer Science");
            TextBook textBookTwo = new TextBook("Python", "Uncle Bob", "Computer Science");
            Assert.AreEqual(0, library.Catalogue.Count);
            library.AddTextBookToLibrary(leisureBook);
            library.AddTextBookToLibrary(textBook);
            library.AddTextBookToLibrary(textBookTwo);

            Assert.AreEqual("Harry Slotter is returned to the library.", library.ReturnTextBook(1));
            Assert.AreEqual("C# complicated is returned to the library.", library.ReturnTextBook(2));
            Assert.AreEqual("Python is returned to the library.", library.ReturnTextBook(3));
            Assert.AreEqual(3, library.Catalogue.Count);
            Assert.AreEqual(string.Empty, leisureBook.Holder);
        }
    }
}