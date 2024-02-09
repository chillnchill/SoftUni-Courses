namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]

        public void Test_TheConstructorShouldWorkCorrectly()
        {
            Warrior warrior = new Warrior("4iflik4i", 100, 100);

            Assert.AreEqual("4iflik4i", warrior.Name);
            Assert.AreEqual(100, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);


            Warrior warriorB = new Warrior("samodategepna", 1, 0);

            Assert.AreEqual("samodategepna", warriorB.Name);
            Assert.AreEqual(1, warriorB.Damage);
            Assert.AreEqual(0, warriorB.HP);

        }

        [TestCase]

        public void Test_TheNameShouldNotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 100, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(null, 100, 100));
            Assert.Throws<ArgumentException>(() => new Warrior(" ", 100, 100));
        }

        [TestCase]

        public void Test_DamageShouldBePositiveNumber()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("sgurio", -1, 100));
            Assert.Throws<ArgumentException>(() => new Warrior("sgurio", 0, 100));

        }

        [TestCase]

        public void Test_HpShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("sgurio", 50, -1));
        }

        [TestCase]
        public void Test_MinHpThreshholdShouldWork()
        {
            Warrior warriorA = new Warrior("puncho", 50, 30);
            Warrior warriorD = new Warrior("puncho2", 50, 59);
            
            Assert.Throws<InvalidOperationException>(() => warriorA.Attack(warriorD));

            warriorA = new Warrior("puncho", 10, 31);
            warriorD = new Warrior("puncho2", 10, 30);

            Assert.Throws<InvalidOperationException>(() => warriorA.Attack(warriorD));

            warriorA = new Warrior("puncho", 10, 49);
            warriorD = new Warrior("puncho2", 51, 50);

            Assert.Throws<InvalidOperationException>(() => warriorA.Attack(warriorD));

        }

        [TestCase]
        public void Test_AttackMethodShouldWork()
        {
            Warrior warriorA = new Warrior("kotio", 50, 50);
            Warrior warriorD = new Warrior("kuchio", 50, 45);
            int expectedFightOutcome = 0;
            warriorA.Attack(warriorD);

            Assert.AreEqual(expectedFightOutcome, warriorD.HP);

            warriorA = new Warrior("kotio", 50, 50);
            warriorD = new Warrior("kuchio", 50, 100);
            expectedFightOutcome = 50;
            warriorA.Attack(warriorD);

            Assert.AreEqual(expectedFightOutcome, warriorD.HP);
            Assert.AreEqual(0, warriorA.HP);

        }
    }
}