using NUnit.Framework;
using System;

namespace RobotFactory.Tests
{
    public class Tests
    {


        [Test]
        public void Test_ConstructorShould_Work()
        {
            Factory factory = new Factory("Baklava", 3);
            Assert.AreEqual("Baklava", factory.Name);
            Assert.AreEqual(3, factory.Capacity);
            Assert.AreEqual(0, factory.Robots.Count);
            Assert.AreEqual(0, factory.Supplements.Count);


        }

        [Test]
        public void Test_ListsShould_Work()
        {
            Factory factory = new Factory("Baklava", 1);
            Robot robot = new Robot("ForkChan", 5500, 10000);
            Supplement supplement = new Supplement("Spoon", 10000);

            factory.Robots.Add(robot);
            Assert.AreEqual("ForkChan", robot.Model);
            Assert.AreEqual(robot.InterfaceStandard, 10000);
            Assert.AreEqual(robot.Price, 5500);
            Assert.AreEqual("Robot model: ForkChan IS: 10000, Price: 5500.00", robot.ToString());

            
            factory.Supplements.Add(supplement);
            Assert.AreEqual(supplement.Name, "Spoon");
            Assert.AreEqual(supplement.InterfaceStandard, 10000);
            Assert.AreEqual("Supplement: Spoon IS: 10000", supplement.ToString());

            Assert.AreEqual(factory.Robots.Count, 1);
            Assert.AreEqual(factory.Supplements.Count, 1);

        }

        [Test]
        public void Test_ProduceRobotShould_Work()
        {
            Factory factory = new Factory("Baklava", 1);
            Assert.AreEqual("Produced --> Robot model: ForkChan IS: 10000, Price: 5500.00", factory.ProduceRobot("ForkChan", 5500, 10000));
            Assert.AreEqual(1, factory.Robots.Count);
        }

        [Test]
        public void Test_ProduceRobotShould_Fail()
        {
            Factory factory = new Factory("Baklava", 1);
            Robot robot = new Robot("ForkChan", 5500, 10000);
            factory.Robots.Add(robot);
            Assert.AreEqual(factory.Robots.Count, factory.Capacity);

            Assert.AreEqual("The factory is unable to produce more robots for this production day!", factory.ProduceRobot("Dork", 4500, 10045));
            Assert.AreEqual(1, factory.Robots.Count);

        }

        [Test]
        public void Test_ProduceSupplement_ShouldWork()
        {
            Factory factory = new Factory("Baklava", 1);
            Assert.AreEqual("Supplement: Spoon IS: 10000", factory.ProduceSupplement("Spoon", 10000));
            Assert.AreEqual("Supplement: Fork IS: 10045", factory.ProduceSupplement("Fork", 10045));
            Assert.AreEqual("Supplement: Chainsaw IS: 10500", factory.ProduceSupplement("Chainsaw", 10500));

            Assert.AreEqual(factory.Supplements.Count, 3);
        }

        [Test]
        public void Test_UpgradeRobot_ShouldWork()
        {
            Factory factory = new Factory("Baklava", 3);
            Robot robot = new Robot("ForkChan", 5500, 10000);
            Supplement supplement = new Supplement("Spoon", 10000);
            factory.Robots.Add(robot);
            factory.ProduceSupplement("Spoon", 10000);
            factory.ProduceSupplement("Fork", 10045);
            factory.ProduceSupplement("Chainsaw", 10500);

            Assert.AreEqual(robot.Supplements.Count, 0);
            Assert.IsTrue(factory.UpgradeRobot(robot, supplement));
            Assert.AreEqual(robot.Supplements.Count, 1);
            
        }
        [Test]
        public void Test_UpgradeRobot_Should_Fail()
        {
            Factory factory = new Factory("Baklava", 3);
            Robot robot = new Robot("ForkChan", 5500, 10500);
            Supplement supplement = new Supplement("Spoon", 10000);
            Assert.AreEqual(factory.Supplements.Count, 0);
            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);

            factory.Supplements.Add(supplement);
            Assert.AreEqual(factory.Supplements.Count, 1);
            Assert.AreEqual(factory.UpgradeRobot(robot, supplement), false);
        }

        [Test]
        public void Test_Sell_Robot_ShouldWork()
        {
            Factory factory = new Factory("Baklava", 3);
            Robot robot = new Robot("ForkChan", 5500, 10500);
            Robot robotTwo = new Robot("Dork", 6000, 1000);
            Robot robotThree = new Robot("Dork", 7000, 11500);

            factory.Robots.Add(robot);
            factory.Robots.Add(robotTwo);
            factory.Robots.Add(robotThree);

            Assert.AreEqual(factory.Robots.Count, 3);

            Assert.AreEqual(factory.SellRobot(5500), robot);
            Assert.AreEqual(factory.SellRobot(7000), robotThree);
            Assert.AreEqual(factory.SellRobot(10000), robotThree);
            Assert.AreEqual(factory.SellRobot(3000), null);
            
        }
    }
}