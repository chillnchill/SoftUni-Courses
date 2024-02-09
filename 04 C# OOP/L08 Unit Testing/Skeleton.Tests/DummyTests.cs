using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private Dummy dummy;
        private Dummy deadDummy;
        private Axe axe;
        private int attackPoints;
        private int durabilityPoints;
        private int healthPoints;
        private int experience;

        [SetUp]

        public void Setup()
        {
            attackPoints = 5;
            durabilityPoints = 15;
            healthPoints = 10;
            experience = 10;
            axe = new Axe(attackPoints, durabilityPoints);
            dummy = new Dummy(healthPoints, experience);
            deadDummy = new Dummy(0, experience);
        }

        [Test]
        public void Test_DummyShouldLoseHealthIfAttacked()
        {
            axe.Attack(dummy);
            Assert.AreEqual(healthPoints - 5, dummy.Health);
        }

        [Test]
        public void Test_DeadDummyShouldThrowExceptionWhenAttacked()
        {
            Assert.Throws<InvalidOperationException> (() => deadDummy.TakeAttack(1));
        }

        [Test]
        public void Test_DeadDummyShouldGiveExperience()
        {
            int dummyExp = deadDummy.GiveExperience();

            Assert.AreEqual(experience, dummyExp);
        }

        [Test]
        public void Test_DummyShouldNotGiveExperienceWhileAlive()
        {
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}