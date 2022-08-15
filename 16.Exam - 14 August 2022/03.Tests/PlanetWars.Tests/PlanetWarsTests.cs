using NUnit.Framework;
using System;
using System.ComponentModel;
using System.Numerics;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            [Test]
            public void Test_WeaponCtor()
            {
                Planet planet = new Planet("asd", 20);

                Assert.AreEqual("asd", planet.Name);

                Assert.AreEqual(20, planet.Budget);

                Assert.AreEqual(0, planet.Weapons.Count);

            }

            [Test]
            public void Test_Name()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("", 20);
                });

                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet(null, 20);
                });

            }


            [Test]
            public void Test_Budget()
            {
                Assert.Throws<ArgumentException>(() =>
                {
                    Planet planet = new Planet("asd", -10);
                });

                Planet planet2 = new Planet("asd", 10);

                Assert.AreEqual(10, planet2.Budget);
            }

            [Test]
            public void Test_AddWeapon()
            {
                var weapon = new Weapon("aaa", 20, 10);

                Planet planet2 = new Planet("asd", 10);

                planet2.AddWeapon(weapon);

                Assert.AreEqual(1, planet2.Weapons.Count);
            }

            [Test]
            public void Test_RemoveWeapon()
            {
                var weapon = new Weapon("aaa", 20, 10);

                var weapon2 = new Weapon("aaaa", 30, 10);


                Planet planet2 = new Planet("asd", 10);

                planet2.AddWeapon(weapon);
                planet2.AddWeapon(weapon2);
                planet2.RemoveWeapon("aaa");

                Assert.AreEqual(1, planet2.Weapons.Count);

                planet2.UpgradeWeapon("aaaa");
                Assert.AreEqual(11, weapon2.DestructionLevel);

                planet2.SpendFunds(1);
                Assert.AreEqual(9, planet2.Budget);

                planet2.Profit(1);
                Assert.AreEqual(10, planet2.Budget);


                var result = planet2.DestructOpponent(new Planet("asd", 10));

                Assert.AreEqual("asd is destructed!", result);



                var weapon3 = new Weapon("a", 10, 5);
                Assert.AreEqual("a", weapon3.Name);
                Assert.AreEqual(10, weapon3.Price);
                Assert.AreEqual(5, weapon3.DestructionLevel);

                var nuclear = weapon3.IsNuclear;

                Assert.AreEqual(false, nuclear);

                weapon3.IncreaseDestructionLevel();
                Assert.AreEqual(6, weapon3.DestructionLevel);

            }
        }
    }
}
