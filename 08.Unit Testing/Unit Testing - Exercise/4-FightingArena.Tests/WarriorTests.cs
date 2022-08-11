namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void Ctor_ShouldSet_DataProperly()
        {
            Warrior warrior = new Warrior("Ivan", 100, 100);

            Assert.AreEqual(warrior.Name, "Ivan");
            Assert.AreEqual(warrior.Damage, 100);
            Assert.AreEqual(warrior.HP, 100);

            warrior = new Warrior("Ivan", 1, 0);
            Assert.AreEqual(warrior.Name, "Ivan");
            Assert.AreEqual(warrior.Damage, 1);
            Assert.AreEqual(warrior.HP, 0);
        }

        [Test]
        public void Ctor_Should_ThrowException_InvalidData()
        {
            Assert.Throws<ArgumentException>(
                () => new Warrior(null, 100, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior(" ", 100, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior("", 100, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Ivan", 0, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Ivan", -1, 100));
            Assert.Throws<ArgumentException>(
                () => new Warrior("Ivan", 60, -1));
        }

        [Test]
        public void Fight_ShouldThrowException_InvalidData()
        {
            Warrior attacker = new Warrior("Ivan", 50, 5);
            Warrior deffender = new Warrior("Sasho", 50, 50);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));

             attacker = new Warrior("Ivan", 50, 100);
             deffender = new Warrior("Sasho", 50, 5);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));

             attacker = new Warrior("Ivan", 50, 50);
             deffender = new Warrior("Sasho", 100, 100);

            Assert.Throws<InvalidOperationException>(
                () => attacker.Attack(deffender));
        }

        [Test]
        public void Fight_ShouldFight_WithValidData()
        {
            Warrior attacker = new Warrior("Ivan", 101, 100);
            Warrior deffender = new Warrior("Sasho", 60, 100); 

            attacker.Attack(deffender);

            Assert.AreEqual(40, attacker.HP);
            
            Assert.AreEqual(0, deffender.HP);

            attacker = new Warrior("Ivan", 50, 100);
            deffender = new Warrior("Sasho", 50, 100);

            attacker.Attack(deffender);

            Assert.AreEqual(50, attacker.HP);

            Assert.AreEqual(50, deffender.HP);
        }
    }
}