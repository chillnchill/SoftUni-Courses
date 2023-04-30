namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(new[] { 1 })]
        [TestCase(new[] { 5, 50, 18, 23, 1000 })]
        [TestCase(new[] { int.MaxValue, int.MinValue })]
        [TestCase(new int[0])]

        public void Test_DoesTheConstructorWork(int[] parameters)
        {
            //Arrange and Act
            Database database = new Database(parameters);

            //Assert
            Assert.AreEqual(parameters.Length, database.Count);
        }

        [TestCase(new[] { 1, 2 },
            new[] { 10, 15 },
            4)]
        [TestCase(new int[0],
            new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            16)]

        public void Test_ValidAddMethod(
            int[] ctorParams,
                int[] paramsToAdd,
                int expectedCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new int[0],
            new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            1)]
        public void Test_InvalidAddMethod(
            int[] ctorParams,
                int[] paramsToAdd,
                int errorParam)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < paramsToAdd.Length; i++)
            {
                database.Add(paramsToAdd[i]);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(errorParam));
        }




        [TestCase(new[] {10,15,24,34},
           new[] { 10, 15, 20, -1, 30 },
           5,
            4)]


        public void Test_ShouldRemoveValidCases(
           int[] ctorParams,
               int[] paramsToRemove,
               int removeCount,
               int expectedCount)
        {
            Database database = new Database(ctorParams);

            foreach (int i in paramsToRemove)
            {
                database.Add(i);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase(new[] {5,3,4,5,6},
            5)]

        [TestCase(new[] { 1},
            1)]
        public void Test_ShouldRemoveInvalidCases(
            int[] ctorParams,
            int removeCount)
        {
            Database database = new Database(ctorParams);

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }



        [TestCase(new[] { 10, 15, 24, 34 },
           new[] { 10, 15, 20, -1, 30 },
           5,
            new[] { 10, 15, 24, 34 })]
        public void Test_FetchShouldReturnCurrentArray(
           int[] ctorParams,
               int[] paramstoAdd,
               int removeCount,
               int[] currentArray)
        {
            Database database = new Database(ctorParams);

            foreach (int i in paramstoAdd)
            {
                database.Add(i);
            }

            for (int i = 0; i < removeCount; i++)
            {
                database.Remove();
            }

            int[] actualData = database.Fetch();

            Assert.AreEqual(currentArray, actualData);
        }
    }
}
