namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test_CreatePresent_ShouldWork()
        {
            Present present = new Present("batman", 69);
            Present present2 = new Present("barbie", 0);
            Present present3 = new Present("4i4ko trevi4ko", -10);

            Assert.AreEqual("batman", present.Name);
            Assert.AreEqual("barbie", present2.Name);
            Assert.AreEqual("4i4ko trevi4ko", present3.Name);
            Assert.AreEqual(69, present.Magic);
            Assert.AreEqual(0, present2.Magic);
            Assert.AreEqual(-10, present3.Magic);

        }

        [Test]
        public void Test_CreateMethod_Should_Work()
        {
            Bag bag = new Bag();
            Present present = new Present("batman", 69);

            Assert.AreEqual("Successfully added present batman.", bag.Create(present));

            Assert.AreEqual(1, bag.GetPresents().Count);

        }


        [Test]
        public void Test_CreateMethod_Should_Bork()
        {
            Bag bag = new Bag();
            Present present = new Present("batman", 69);
            bag.Create(present);

            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));

        }

        [Test]
        public void Test_RemoveMethod_Should_Work()
        {
            Bag bag = new Bag();
            Present present = new Present("batman", 69);
            bag.Create(present);

            Assert.AreEqual(true, bag.Remove(present));
            Assert.AreEqual(false, bag.Remove(present));
        }

        [Test]
        public void Test_LeastMagicMethod_Should_Work()
        {
            Bag bag = new Bag();
            Present present = new Present("batman", 69);
            Present present2 = new Present("barbie", 0);
            Present present3 = new Present("4i4ko trevi4ko", -10);
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Assert.AreEqual(present3, bag.GetPresentWithLeastMagic());
        }


        [Test]
        public void Test_GetPresentMethod_Should_Work()
        {
            Bag bag = new Bag();
            Present present = new Present("batman", 69);

            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent("batman"));
            Assert.AreEqual(null, bag.GetPresent("4o4o"));

        }


        [Test]
        public void Test_GetPresentsMethod_Should_Work()
        {
            Bag bag = new Bag();
            Present[] actual = new[]
            {
                new Present("batman", 69),
                new Present("barbie", 0),
                new Present("4i4ko trevi4ko", -10)
            };

            foreach (Present present in actual)
            {
                bag.Create(present);
            }

            IReadOnlyCollection<Present> presents = bag.GetPresents();
            Assert.AreEqual(presents, actual);

        }
    }
}
