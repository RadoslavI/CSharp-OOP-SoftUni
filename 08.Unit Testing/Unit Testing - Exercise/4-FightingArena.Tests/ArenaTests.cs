namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void Constructor_Should_Initialize_Data()
        {
            Arena arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
            Assert.AreEqual(arena.Warriors.Count, arena.Count);

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void Enroll_ShouldAddWarriors_ValidDate()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("gosho", 100, 100);

            arena.Enroll(warrior);

            Assert.AreEqual(1, arena.Count);

            Assert.True(arena.Warriors.Any(x => x.Name == "gosho"));
        }

        [Test]
        public void Enroll_ShouldThrowException_InvalidDate()
        {
            Arena arena = new Arena();

            Warrior warrior = new Warrior("gosho", 100, 100);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(
                () => arena.Enroll(warrior));
        }

        [Test]
        public void Fight_ShouldReduceDamage_ValidData()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Ivan", 101, 100);
            Warrior deffender = new Warrior("Sasho", 60, 100);

            arena.Enroll(attacker);
            arena.Enroll(deffender);

            arena.Fight("Ivan", "Sasho");

            Assert.AreEqual(40, attacker.HP);
            Assert.AreEqual(0, deffender.HP);
        }

        [Test]
        public void Fight_ShouldThrowException_WarriorDoesntExist()
        {
            Arena arena = new Arena();

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Ivan", "Sasho"));

            arena.Enroll(new Warrior("Ivan", 100, 100));

            Assert.Throws<InvalidOperationException>(
                () => arena.Fight("Ivan", "Sasho"));
        }

        [Test]
        public void Test_Fight_With_Existing_Warriors_Should_Not_Throw_Exception()
        {
            Arena arena = new Arena();
            Warrior warrior = new Warrior("Brom", 50, 90);
            Warrior defender = new Warrior("Razgar", 50, 100);
            arena.Enroll(warrior);
            arena.Enroll(defender);

            arena.Fight("Brom", "Razgar");

            Assert.AreEqual(40, warrior.HP, "First warrior HP does not match.");
            Assert.AreEqual(50, defender.HP, "Second warrior HP does not match.");
        }
    }
}
