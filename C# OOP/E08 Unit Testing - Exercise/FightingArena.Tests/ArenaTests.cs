namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Test_CountMethodShouldWorkCorrectly()
        {
            Arena arena = new Arena();
            
            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);
            Assert.AreEqual(0, arena.Count);

        }

        [TestCase]
        public void Test_EntrollMethodShouldThrowErrorsNowAndThen()
        {
            Arena arena = new Arena();
            Warrior warriorA = new Warrior("kotio", 50, 50);
            Warrior warriorD = new Warrior("kuchio", 50, 45);
            arena.Enroll(warriorA);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warriorA));
        }

        [TestCase]
        public void Test_EntrollMethodShouldEnrollCorrectly()
        {
            Arena arena = new Arena();
            Warrior warriorA = new Warrior("kotio", 50, 50);
            Warrior warriorD = new Warrior("kuchio", 50, 45);
            int expectedCount = 2;
            arena.Enroll(warriorA);
            arena.Enroll(warriorD);

            Assert.AreEqual(expectedCount, arena.Count);
            Assert.True(arena.Warriors.Any(n => n.Name == warriorA.Name));
            Assert.True(arena.Warriors.Any(n => n.Name == warriorD.Name));
        }

        [TestCase]

        public void Test_FightMethodGivesErrorWhenFighterNotPresent()
        {
            Arena arena = new Arena();
            Warrior warriorA = new Warrior("kotio", 50, 50);
            Warrior warriorD = new Warrior("kuchio", 50, 45);

            arena.Enroll(warriorA);

            Assert.Throws<InvalidOperationException> (() => arena.Fight(warriorA.Name, warriorD.Name));

        }

        [TestCase]

        public void Test_FightMethodShouldWorkProperly()
        {
            Arena arena = new Arena();
            Warrior warriorA = new Warrior("kotio", 50, 100);
            Warrior warriorD = new Warrior("kuchio", 50, 100);
            int expectedOutcome = 50;
            arena.Enroll(warriorA);
            arena.Enroll (warriorD);
            arena.Fight(warriorA.Name, warriorD.Name);

            Assert.AreEqual(expectedOutcome, warriorD.HP);
            Assert.AreEqual(expectedOutcome, warriorA.HP);
        }
    }
}
