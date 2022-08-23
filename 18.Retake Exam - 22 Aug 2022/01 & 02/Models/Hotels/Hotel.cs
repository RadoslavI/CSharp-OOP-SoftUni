using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private IRepository<IRoom> rooms = new RoomRepository();
        private IRepository<IBooking> bookings = new BookingRepository();

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                fullName = value;
            }
        }

        public int Category
        {
            get => category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                category = value;
            }
        }

        public double Turnover => GetResult();

        IRepository<IRoom> IHotel.Rooms { get => this.rooms; set => rooms = value; }
        IRepository<IBooking> IHotel.Bookings { get => this.bookings; set => bookings = value; }

        private double GetResult()
        {
            var result = this.bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight);
            return result;
        }
    }
}
