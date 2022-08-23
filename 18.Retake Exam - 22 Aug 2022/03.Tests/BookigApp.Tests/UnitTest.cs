using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Room_Tests()
        {
            Room room = new Room(2, 20);
            Assert.AreEqual(20, room.PricePerNight);
            Assert.AreEqual(2, room.BedCapacity);

            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(2, -20);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Room room = new Room(-2, 20);
            });
        }

        [Test]
        public void Test_Booking()
        {

            Room room = new Room(2, 20);
            Booking booking = new Booking(14, room, 5);
            Assert.AreEqual(14, booking.BookingNumber);
            Assert.AreEqual(5, booking.ResidenceDuration);
            Assert.AreSame(room, booking.Room);

            //Assert.Throws<ArgumentException>(() =>
            //{
            //    Room room = new Room(2, -20);
            //});

            //Assert.Throws<ArgumentException>(() =>
            //{
            //    Room room = new Room(-2, 20);
            //});
        }

        [Test]
        public void Hotel_Tests()
        {

            Hotel hotel = new Hotel("perla", 3);
            Assert.AreEqual("perla", hotel.FullName);
            Assert.AreEqual(3, hotel.Category);
            Assert.AreEqual(0, hotel.Turnover);

            Assert.Throws<ArgumentNullException>(() =>
            {
                Hotel hotel = new Hotel(null, 3);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                Hotel hotel = new Hotel("perla", -3);
            });

            hotel.AddRoom(new Room(5, 20));

            Assert.AreEqual(1, hotel.Rooms.Count);
            Assert.AreEqual(0, hotel.Bookings.Count);

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(-2, 3, 2, 200);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, -3, 2, 200);
            });

            Assert.Throws<ArgumentException>(() =>
            {
                hotel.BookRoom(2, 3, -2, 200);
            });

            hotel.BookRoom(2, 3, 2, 2000);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(40, hotel.Turnover);

            //Room room = new Room(2, 20);
            //Booking booking = new Booking(14, room, 5);
            //Assert.AreEqual(14, booking.BookingNumber);
            //Assert.AreEqual(5, booking.ResidenceDuration);
            //Assert.AreSame(room, booking.Room);

            //Assert.Throws<ArgumentException>(() =>
            //{
            //    Room room = new Room(2, -20);
            //});

            //Assert.Throws<ArgumentException>(() =>
            //{
            //    Room room = new Room(-2, 20);
            //});
        }
    }
}