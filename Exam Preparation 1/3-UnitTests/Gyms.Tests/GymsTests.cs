using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    public class GymsTests
    {
        [Test]
        public void Test_Athlete_Creation()
        {
            Athlete athlete = new Athlete("Ivan");

            Assert.AreEqual("Ivan", athlete.FullName);
            Assert.AreEqual(false, athlete.IsInjured);
        }

        [Test]
        public void Test_Gym_Creation()
        {
            Gym gym = new Gym("Tempo", 20);

            Assert.AreEqual("Tempo", gym.Name);
            Assert.AreEqual(20, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void Test_Gym_Creation_WithNullName_Throws()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Gym gym = new Gym(null, 20);
            });
        }

        [Test]
        public void Test_Gym_Creation_WithNegaticeCapacity_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Gym gym = new Gym("Gym", -1);
            });
        }

        [Test]
        public void Test_Gym_AddAthlete_Positive()
        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Vanko1");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_Gym_AddAthlete_Negative_ShouldThrow()
        {
            Gym gym = new Gym("Gym", 1);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.AddAthlete(athlete1);
            });
        }

        [Test]
        public void Test_Gym_RemoveAthlete_Positive()
        {
            Gym gym = new Gym("Gym", 2);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            gym.RemoveAthlete("Vanko1");

            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void Test_Gym_RemoveAthlete_Negative_ShouldThrow()
        {
            Gym gym = new Gym("Gym", 2);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Sasho");
            });

        }
        
        [Test]
        public void Test_Gym_InjureAthlete_Negative_ShouldThrow()

        {
            Gym gym = new Gym("Gym", 2);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete("Sasho");
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                gym.RemoveAthlete(null);
            });
        }

        [Test]
        public void Test_Gym_InjureAthlete_Positive()

        {
            Gym gym = new Gym("Gym", 2);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);

            var returnAthlete = gym.InjureAthlete(athlete.FullName);

            Assert.AreEqual(true, athlete.IsInjured);
             
            //IMPORTANT! WE HAVE TO CHECK IF IT IS RETURNED CORRECTLY!!!
            Assert.AreSame(returnAthlete, athlete);
        }

        [Test]
        public void Test_Gym_Report_Positive()

        {
            Gym gym = new Gym("Gym", 3);

            var athlete = new Athlete("Vanko1");
            var athlete1 = new Athlete("Vanko2");
            gym.AddAthlete(athlete);
            gym.AddAthlete(athlete1);
            gym.InjureAthlete("Vanko1");

            var expectedReport1 = $"Active athletes at {gym.Name}: {athlete1.FullName}";
            Assert.AreEqual(expectedReport1, gym.Report());

            gym.AddAthlete(new Athlete("Koko"));
            var expectedReport2 = $"Active athletes at {gym.Name}: {athlete1.FullName}, Koko";
            Assert.AreEqual(expectedReport2, gym.Report());
        }
    }
}
