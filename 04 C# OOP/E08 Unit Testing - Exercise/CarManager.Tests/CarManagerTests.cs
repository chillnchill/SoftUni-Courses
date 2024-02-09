namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.ConstrainedExecution;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void Setup()
        {
            car = new Car("BMW", "X5", 13.3, 82.9);
        }

        [TearDown]
        public void Teardown()
        {
            car = null;
        }

        [Test]
        public void TestCar()
        {
            Assert.AreEqual("BMW", car.Make);
            Assert.AreEqual("X5", car.Model);
            Assert.AreEqual(13.3, car.FuelConsumption);
            Assert.AreEqual(82.9, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }


        [Test]
        public void Test_CarConstructorShouldConstructCar()
        {
            List<Car> cars = new List<Car>();
            Car car = new Car("BMW", "X5 M60i", 13.3, 82.9);
            Car carTwo = new Car("Opel", "Vectra", 10, 55.5);

            cars.Add(car);
            cars.Add(carTwo);

            Assert.AreEqual(2, cars.Count);
        }

        [Test]
        public void Test_CarMakeShouldNotBeEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() => new Car(string.Empty, "X5 M60i", 13.3, 82.9));
            Assert.Throws<ArgumentException>(() => new Car(null, "X5 M60i", 13.3, 82.9));
            Assert.Throws<ArgumentException>(() => new Car("", "X5 M60i", 13.3, 82.9));
        }

        [Test]
        public void Test_CarModelShouldNotBeEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", string.Empty, 13.3, 82.9));
            Assert.Throws<ArgumentException>(() => new Car("BMW", null, 13.3, 82.9));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "", 13.3, 82.9));
        }

        [Test]
        public void Test_FuelConsumptionShouldNotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5 M60i", 0, 82.9));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5 M60i", -10, 82.9));

        }
        [Test]
        public void Test_FuelAmountCanNotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5 M60i", 15.5, -82.9));
        }

        [Test]
        public void Test_FuelCapacityShouldNotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5 M60i", 15.5, 0));
            Assert.Throws<ArgumentException>(() => new Car("BMW", "X5 M60i", 15.5, -82.9));
        }

        [Test]
        public void Test_RefuelMethodShould_Work()
        {
            double amountToFuel = 82.9;
            Car car = new Car("BMW", "X5 M60i", 15.5, 82.9);

            car.Refuel(amountToFuel);

            Assert.AreEqual(amountToFuel, car.FuelAmount);
        }

        [Test]
        public void Test_RefuelMethodShould_NotWork()
        {
            double amountToFuelFirst = -82.9;
            double amountToFuelSecond = 0;

            Car car = new Car("BMW", "X5 M60i", 15.5, 82.9);
            Car carTwo = new Car("Opel", "Vectra", 10, 55.5);

            Assert.Throws<ArgumentException> (() => car.Refuel(amountToFuelFirst));
            Assert.Throws<ArgumentException> (() => carTwo.Refuel(amountToFuelSecond));            
        }

        [Test]
        public void Test_DriveMethodShould_Work()
        {
            Car car = new Car("BMW", "X5 M60i", 15.5, 82.9);

            Assert.Throws<InvalidOperationException>(() => car.Drive(50));
            Assert.Throws<InvalidOperationException>(() => car.Drive(15.50));
        }
    }
}