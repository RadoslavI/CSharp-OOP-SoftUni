using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void Test_Car()
            {
                Car testCar = new Car("Accord", 0);

                Assert.AreEqual("Accord", testCar.CarModel);
                Assert.AreEqual(0, testCar.NumberOfIssues);
                Assert.AreEqual(true, testCar.IsFixed);
            }

            [Test]
            public void Test_Garage()
            {
                Car testCar1 = new Car("Accord", 0);
                Car testCar2 = new Car("BMW", 2);
                List<Car> cars = new List<Car>();
                cars.Add(testCar1);
                cars.Add(testCar2);

                Garage garage = new Garage("Shondi", 3);
                Assert.AreEqual("Shondi", garage.Name);
                Assert.AreEqual(3, garage.MechanicsAvailable);
                Assert.AreEqual(0, garage.CarsInGarage);


                Assert.Throws<ArgumentNullException>(() =>
                {
                    Garage garage = new Garage(null, 3);
                }
                );

                Assert.Throws<ArgumentException>(() =>
                {
                    Garage garage = new Garage("asda", -2);
                }
                );

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Garage garage = new Garage("asda", 1);
                    garage.AddCar(testCar1);
                    garage.AddCar(testCar2);
                }
                );

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Garage garage = new Garage("asda", 1);
                    garage.FixCar("nocarmadafaka");
                }
                );

                garage.AddCar(testCar2);
                Assert.AreSame(testCar2, garage.FixCar("BMW"));

                Assert.Throws<InvalidOperationException>(() =>
                {
                    Garage garage = new Garage("asda", 1);
                    garage.RemoveFixedCar();
                }
                );

                Assert.AreEqual(1, garage.RemoveFixedCar());

                garage = new Garage("asda", 1);
                string output = garage.Report();

                Assert.AreEqual($"There are {0} which are not fixed: .", output);
            }

        }
    }
}