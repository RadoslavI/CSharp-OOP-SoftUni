namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [Test]
        public void Test_Bag_Create()
        {
            Bag bag = new Bag();
            var present = new Present("podaruk1", 20.20);

            Assert.Throws<ArgumentNullException>(() =>
            {
                bag.Create(null);
            });

            string result = bag.Create(present);

            Assert.AreEqual("Successfully added present podaruk1.", result);

            Assert.Throws<InvalidOperationException>(() =>
            {
                bag.Create(present);
            });
        }

        [Test]
        public void Test_Bag_Remove()
        {
            Bag bag = new Bag();
            var present = new Present("podaruk1", 20.20);
            bag.Create(present);
            bool result = bag.Remove(present);
            Assert.AreEqual(true, result);
            result = bag.Remove(present);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Test_Bag_GetPresentWithLeastMagic()
        {
            Bag bag = new Bag();
            var present1 = new Present("podaruk1", 20.20);
            var present2 = new Present("podaruk2", 10);
            bag.Create(present1);
            bag.Create(present2);

            var resultPresent = bag.GetPresentWithLeastMagic();

            Assert.AreSame(present2, resultPresent);
        }

        [Test]
        public void Test_Bag_GetPresent()
        {
            Bag bag = new Bag();
            var present1 = new Present("podaruk1", 20.20);
            var present2 = new Present("podaruk2", 10);
            bag.Create(present1);
            bag.Create(present2);

            var resultPresent = bag.GetPresent("podaruk2");

            Assert.AreSame(present2, resultPresent);
        }
    }
}
