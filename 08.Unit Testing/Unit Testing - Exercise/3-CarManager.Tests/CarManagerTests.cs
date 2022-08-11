namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void CtorShouldSetValuesProperly()
        {
            Car car = new Car("Honda", "Accord", 0.06, 65);

            Assert.AreEqual(car.Make, "Honda");
            Assert.AreEqual(car.Model, "Accord");
            Assert.AreEqual(car.FuelConsumption, 0.06);
            Assert.AreEqual(car.FuelCapacity, 65);
            Assert.AreEqual(car.FuelAmount, 0);

            car = new Car("Honda", "Accord", double.MaxValue, double.MaxValue);

            Assert.AreEqual(car.Make, "Honda");
            Assert.AreEqual(car.Model, "Accord");
            Assert.AreEqual(car.FuelConsumption, double.MaxValue);
            Assert.AreEqual(car.FuelCapacity, double.MaxValue);
            Assert.AreEqual(car.FuelAmount, 0);
        }

        [Test]
        public void Ctor_ShouldThrowException_InvalidData()
        {            
            Assert.Throws<ArgumentException>(
                () => new Car(null, "Accord", 0.06, 65));
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", null, 0.06, 65));
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Accord", 0, 65));
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Accord", -5, 65));
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Accord", 10, 0));
            Assert.Throws<ArgumentException>(
                () => new Car("Honda", "Accord", 10, -5));
        }

        [Test]
        public void Refuel_ShouldRefuelCar_ValidData()
        {
            Car car = new Car("Honda", "Accord", 0.06, 65);
            car.Refuel(50);
            Assert.AreEqual(car.FuelAmount, 50);

            car = new Car("Honda", "Accord", 0.06, 65);
            car.Refuel(65);
            Assert.AreEqual(car.FuelAmount, 65);

            car = new Car("Honda", "Accord", 0.06, 65);
            car.Refuel(1);
            Assert.AreEqual(car.FuelAmount, 1);

            car = new Car("Honda", "Accord", 0.06, 65);
            car.Refuel(100);
            Assert.AreEqual(car.FuelAmount, 65);
        }

        [Test]
        public void Refuel_ShouldThrowException_InvalidData()
        {
            Car car = new Car("Honda", "Accord", 0.06, 65);            
            Assert.Throws<ArgumentException>(
                () => car.Refuel(0));

            car = new Car("Honda", "Accord", 0.06, 65);
            Assert.Throws<ArgumentException>(
                () => car.Refuel(-5));
        }

        [Test]
        public void Drive_ShouldDecreaseFuelAmount_ValidData()
        {
            Car car = new Car("Honda", "Accord", 5, 65);
            car.Refuel(100);
            car.Drive(100);

            Assert.AreEqual(car.FuelAmount, 60);
        }

        [Test]
        public void Drive_ShouldThrowException_InvalidData()
        {
            Car car = new Car("Honda", "Accord", 6, 65);
            car.Refuel(1);
            Assert.Throws<InvalidOperationException>(
                () => car.Drive(100));
        }
    }
}