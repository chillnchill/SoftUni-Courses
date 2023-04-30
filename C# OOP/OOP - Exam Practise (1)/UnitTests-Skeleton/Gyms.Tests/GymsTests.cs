using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Gyms.Tests
{
    public class GymsTests
    {
        // Implement unit tests here

        [Test]
        public void Test_AthleteConstructorShouldWork()
        {
            string name = "jechko";
            Athlete dork = new Athlete(name);

            Assert.AreEqual("jechko", dork.FullName);
            Assert.AreEqual(false, dork.IsInjured);
        }



        [Test]
        public void Test_GymConstructorShouldWork()
        {
            string name = "Nacepenqci";
            int capacity = 100;
            Gym gym = new Gym(name, capacity);
            

            Assert.AreEqual(name, gym.Name);
            Assert.AreEqual(capacity, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
           
        }



        [Test]
        public void Test_GymCountShouldWork()
        {
            Gym gym = new Gym("Qki patki", 10);
            gym.AddAthlete(new Athlete("mnqk"));
            gym.AddAthlete(new Athlete("nacepin"));

            Assert.AreEqual(2, gym.Count);
        }

        [Test]
        public void Test_GymNameShouldNotBe_Null()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 15);
            });
        }

        public void Test_GymNameShouldNotBe_Empty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym("", 15);
            });
        }



        [Test]
        public void Test_GymCapacityShouldNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Qki patki", -10);
            });
        }


 
        [Test]
        public void Test_Gym_AddAthlete_ShouldWork()
        {
            string name = "jechko";
            Athlete dork = new Athlete(name);
            Gym gym = new Gym("Qki patki", 10);
            gym.AddAthlete(dork);

            Assert.AreEqual(1, gym.Count);

        }

        [Test]
        public void Test_Gym_AddAthlete_ShoulNotdWork()
        {
            Athlete dork = new Athlete("jechko");
            Gym gym = new Gym("Qki patki", 1);
            gym.AddAthlete(dork);

            Assert.Throws< InvalidOperationException>(() => gym.AddAthlete(new Athlete("spas")));
        }

        [Test]
        public void Test_Gym_RemoveAthlete_ShouldWork()
        {
            Athlete dork = new Athlete("jechko");
            Gym gym = new Gym("Qki patki", 1);

            gym.AddAthlete(dork);
            Assert.AreEqual(1, gym.Count);

            gym.RemoveAthlete(dork.FullName);
            Assert.AreEqual(0, gym.Count);

        }


        [Test]
        public void Test_Gym_RemoveAthlete_ShouldThrow()
        {
            Gym gym = new Gym("Qki patki", 2);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("spas"));

            Athlete dork = new Athlete("jechko");
            gym.AddAthlete(dork);

            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("penX"));
        }


        [Test]
        public void Test_Gym_InjuredAthlete_Works()
        {
            Athlete dork = new Athlete("jechko");
            Gym gym = new Gym("Qki patki", 2);
            gym.AddAthlete(dork);

            gym.InjureAthlete("jechko");
            Assert.AreEqual(true, dork.IsInjured);

        }

        [Test]
        public void Test_Gym_InjuredAthlete_Borks()
        {
            Gym gym = new Gym("Qki patki", 1);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("penX"));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(""));
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete(null));
        }

        [Test]
        public void Test_Gym_Report_ShouldWork_WithAthlete()
        {
            Athlete dork = new Athlete("jechko");
            Athlete pork = new Athlete("spas");
            Gym gym = new Gym("Qki patki", 2);
            gym.AddAthlete(dork);
            gym.AddAthlete(pork);
            gym.InjureAthlete("spas");
            var report = gym.Report();

            Assert.AreEqual("Active athletes at Qki patki: jechko", gym.Report());

        }

        [Test]
        public void Test_Gym_Report_ShouldWork_WhenGymEmpty()
        {
            Gym gym = new Gym("Qki patki", 2);
            var report = gym.Report();

            Assert.AreEqual("Active athletes at Qki patki: ", gym.Report());
        }


        [Test]
        public void Test_Gym_Report_ShouldWork_WithAthletes()
        {
            Athlete dork = new Athlete("jechko");
            Athlete pork = new Athlete("spas");
            Gym gym = new Gym("Qki patki", 2);
            gym.AddAthlete(dork);
            gym.AddAthlete(pork);
            var report = gym.Report();

            Assert.AreEqual("Active athletes at Qki patki: jechko, spas", gym.Report());

        }
    }
}
