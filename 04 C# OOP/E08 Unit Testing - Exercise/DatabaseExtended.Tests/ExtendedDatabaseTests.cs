namespace ExtendedDatabase.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ExtendedDatabaseTests
    {


        [TestCaseSource("TestCaseConstructorData")]

        public void Test_DoesTheConstructorWork(Person[] people,
            int expectedCount)
        {
            //Arrange and Act
            Database database = new Database(people);

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCaseSource("TestCaseAddMethod")]

        public void Test_AddMethodShouldWorkSuccessfully(Person[] peopleCtor,
            Person[] peopleToAdd,
            int expectedCount)
        {
            //Arrange and Act
            Database database = new Database(peopleCtor);

            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }

            //Assert
            Assert.AreEqual(expectedCount, database.Count);
        }

        [TestCase]
        public void Test_FindByIDShouldReturnID()
        {
            Person person = new Person(241, "Ailqk");
            Person person2 = new Person(2421, "scrubber");
            Database database = new Database(person, person2);
            long iDnumb = 241;

            Assert.AreEqual(person, database.FindById(iDnumb));
        }

        [TestCase]
        public void Test_FindByUserNameShouldReturnErrorWhen_IdIsWrong()
        {
            Person person = new Person(241, "Ailqk");
            Person person2 = new Person(2421, "scrubber");
            Database database = new Database(person, person2);
            long iDnumber = 2241;

            Assert.Throws<InvalidOperationException>(() => database.FindById(iDnumber));
        }

        [Test]
        public void Test_FindByUserNameShouldReturnErrorWhen_NegativeNumber()
        {
            Person person = new Person(241, "Ailqk");
            Person person2 = new Person(2421, "scrubber");
            Database database = new Database(person, person2);
            long iDnum = -241;

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(iDnum));
        }

        [TestCase]
        public void Test_FindByUserNameShouldReturnUser()
        {
            Person person = new Person(241, "Ailqk");
            Person person2 = new Person(2421, "scrubber");
            Database database = new Database(person, person2);
            string properUser = "Ailqk";

            Assert.AreEqual(person, database.FindByUsername(properUser));

        }

        [TestCase]
        public void Test_FindByUserNameShouldReturnErrorWhen_Empty()
        {
            Person person = new Person(241, "Ailqk");
            Database database = new Database(person);
            string emptyUser = "";

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(emptyUser));
        }

        [TestCase]
        public void Test_FindByUserNameShouldReturnErrorWhen_Wrong()
        {
            Person person = new Person(241, "Ailqk");
            Person person2 = new Person(2421, "scrubber");
            Database database = new Database(person);
            string wrongUser = "penio";
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(wrongUser));

        }

        [TestCase]
        public void Test_RemoveMethodShouldNotWork()
        {
            Person person = new Person(241, "Ailqk");
            Database database = new Database(person);

            database.Remove();

            Assert.Throws<InvalidOperationException>(() => database.Remove());

        }

        [TestCaseSource("TestCaseRemoveData")]
        public void Test_RemoveMethodShouldWorkSuccessfully(Person[] peopleCtor,
            Person[] peopleToAdd,
            int peopleToRemove,
            int expectedCount)
        {
            Database database = new Database(peopleCtor);

            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }

            for (int i = 0; i < peopleToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(expectedCount, database.Count);
        }
        public static IEnumerable<TestCaseData> TestCaseRemoveData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Person[]
            {
                new Person(1231, "joro"),
                new Person(12331, "kiro"),
                new Person(1254331, "roki"),

            },
            new Person[]
            {
                new Person(12231, "jsoro"),
                new Person(123361, "jordo"),
                new Person(14231, "josro"),
            },
            2, 4)

        };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        [TestCaseSource("TestCaseAddMethodThrowsException")]
        public void Test_AddMethodShouldThrowException(Person[] peopleCtor,
            Person[] peopleToAdd,
            Person extraPerson)
        {
            Database database = new Database(peopleCtor);

            foreach (Person person in peopleToAdd)
            {
                database.Add(person);
            }

            Assert.Throws<InvalidOperationException>(() => database.Add(extraPerson));

        }

        public static IEnumerable<TestCaseData> TestCaseAddMethodThrowsException()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Person[]
            {
                new Person(1, "joro"),
                new Person(2, "kiro"),
                new Person(3, "roki"),
                new Person(4, "joros"),
                new Person(5, "kirrro"),
                new Person(6, "ret"),
                new Person(7, "ert"),
                new Person(8, "rt"),
                new Person(9, "rsroeeki"),
                new Person(10, "rsrrokei"),
                new Person(11, "rrrsoki"),
                new Person(12, "rsotki"),
                new Person(13, "rsorki"),

            },
            new Person[]
            {
                new Person(14, "rsoaki"),
                new Person(15, "rsoa24ki"),
                new Person(16, "rsoas24ki"),
            },
            new Person(17, "bostanji")
            ),
            new TestCaseData(new Person[]
            {
            },
            new Person[]
            {
                new Person(12435333231, "joros"),
                new Person(1243533331, "kirro"),
                new Person(125454331, "rsoki"),
            },
            new Person(1243533331, "bostanji")
            ),
            new TestCaseData(new Person[]
            {
            },
            new Person[]
            {
                new Person(11, "joros"),
                new Person(4453, "kSirro"),
                new Person(22, "kirro"),
                new Person(223, "bostanji"),
            },
            new Person(17, "bostanji")
            ),

            };


            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseAddMethod()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Person[]
            {
                new Person(1231, "joro"),
                new Person(12331, "kiro"),
                new Person(1254331, "roki"),

            },
            new Person[]
            {
                new Person(12431, "joros"),
                new Person(1243533331, "kirro"),
                new Person(125454331, "rsoki"),
            },
            6),
            new TestCaseData(new Person[]
            {
            },
            new Person[]
            {
                new Person(12431, "joros"),
                new Person(1243533331, "kirro"),
                new Person(125454331, "rsoki"),
            },
            3)

        };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }

        public static IEnumerable<TestCaseData> TestCaseConstructorData()
        {
            TestCaseData[] testCases = new TestCaseData[]
            {
                new TestCaseData(new Person[]
            {
                new Person(1231, "joro"),
                new Person(12331, "kiro"),
                new Person(1254331, "roki"),

            },
            3),
            new TestCaseData(new Person[]
            {
            },
            0)
        };

            foreach (var item in testCases)
            {
                yield return item;
            }
        }
    }
}
