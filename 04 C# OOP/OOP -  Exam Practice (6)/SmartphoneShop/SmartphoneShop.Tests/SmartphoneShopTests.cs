using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {

        [Test]
        public void TestShop_Constructor()
        {
            Smartphone smartySmartPhone = new Smartphone("iPhone 4", 0);
            Smartphone smarterPhone = new Smartphone("Xiaomi Redmi Note 9 Pro", 50);
            Smartphone smartPhone = new Smartphone("Nokia 3310", 100);
            Shop shop = new Shop(3);

            Assert.AreEqual(0, shop.Count);

            shop.Add(smarterPhone);
            shop.Add(smartPhone);
            shop.Add(smartySmartPhone);

            Assert.AreEqual(3, shop.Count);
        }

        [Test]
        public void TestShop_Capacity()
        {
            
            Shop shop;
            Assert.Throws<ArgumentException>(() => shop = new Shop(-1));

            shop = new Shop(5);
            Assert.AreEqual(5, shop.Capacity);

            shop = new Shop(0);
            Assert.AreEqual(0, shop.Capacity);
            Assert.AreEqual(0, shop.Count);
        }

        [Test]
        public void Shop_AddPhone_ShouldWork()
        {
            Smartphone smartySmartPhone = new Smartphone("iPhone 4", 0);
            Smartphone smarterPhone = new Smartphone("Xiaomi Redmi Note 9 Pro", 50);
            Smartphone smartPhone = new Smartphone("Nokia 3310", 100);
            Shop shop = new Shop(2);
            Assert.AreEqual(0, shop.Count);
            shop.Add(smartySmartPhone);
            shop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartySmartPhone));
            Assert.Throws<InvalidOperationException>(() => shop.Add(smarterPhone));
            Assert.AreEqual(2, shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Add(smartPhone));
            Assert.Throws<InvalidOperationException>(() => shop.Add(new Smartphone("Nokia 3310", 1000)));
            Assert.AreEqual(2, shop.Count);

        }

        [Test]
        public void Shop_RemovePhone_ShouldWork()
        {
            Smartphone smarterPhone = new Smartphone("Xiaomi Redmi Note 9 Pro", 50);
            Smartphone smartPhone = new Smartphone("Nokia 3310", 100);
            Shop shop = new Shop(2);

            shop.Add(smartPhone);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Xiaomi Redmi Note 9 Pro"));
            Assert.AreEqual(1, shop.Count);
            shop.Remove("Nokia 3310");
            Assert.AreEqual(0, shop.Count);
            Assert.Throws<InvalidOperationException>(() => shop.Remove("Xiaomi Redmi Note 9 Pro"));
        }

        [Test]
        public void Shop_TestPhone_ShouldWork()
        {
            Smartphone smartySmartPhone = new Smartphone("iPhone 4", 1);
            Smartphone smarterPhone = new Smartphone("Xiaomi Redmi Note 9 Pro", 50);
            Smartphone smartPhone = new Smartphone("Nokia 3310", 100);
            Shop shop = new Shop(2);

            shop.Add(smartySmartPhone);
            shop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Xiaomi Redmi Note 9 Pro", 50));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Nokia 3310", 110));
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("iPhone 4", 2));

            Assert.AreEqual(smartPhone.CurrentBateryCharge, 100);
            shop.TestPhone("Nokia 3310", 50);
            Assert.AreEqual(smartPhone.CurrentBateryCharge, 50);
            shop.TestPhone("iPhone 4", 1);
            Assert.AreEqual(smartySmartPhone.CurrentBateryCharge, 0);

        }
        [Test]
        public void Shop_ChargePhone_ShouldWork()
        {
            Smartphone smartySmartPhone = new Smartphone("iPhone 4", 1);
            Smartphone smarterPhone = new Smartphone("Xiaomi Redmi Note 9 Pro", 50);
            Smartphone smartPhone = new Smartphone("Nokia 3310", 100);
            Shop shop = new Shop(3);

            shop.Add(smartySmartPhone);
            shop.Add(smartPhone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Xiaomi Redmi Note 9 Pro"));

            shop.Add(smarterPhone);
            Assert.AreEqual(smarterPhone.CurrentBateryCharge, 50);
            smarterPhone.CurrentBateryCharge = 0;
            Assert.AreEqual(smarterPhone.CurrentBateryCharge, 0);
            shop.ChargePhone("Xiaomi Redmi Note 9 Pro");
            Assert.AreEqual(smarterPhone.CurrentBateryCharge, 50);

            smarterPhone.CurrentBateryCharge = -10;
            Assert.AreEqual(smarterPhone.CurrentBateryCharge, -10);
            shop.ChargePhone("Xiaomi Redmi Note 9 Pro");
            Assert.AreEqual(smarterPhone.CurrentBateryCharge, 50);

        }
    }
}