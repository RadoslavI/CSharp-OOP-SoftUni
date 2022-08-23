using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;
        public Controller()
        {
            hotels = new HotelRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(x => x.FullName == hotelName))
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            hotels.AddNew(new Hotel(hotelName, category));
            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            int neededCapacity = adults + children;
            var orderedHotels = hotels.All().OrderBy(x => x.FullName);
            var currRooms = orderedHotels.SelectMany(x => x.Rooms.All().Where(r => r.PricePerNight > 0));
            var orderedRooms = currRooms.OrderBy(z => z.BedCapacity);
            var chosenRoom = orderedRooms.FirstOrDefault(z => z.BedCapacity >= neededCapacity);

            if (!hotels.All().Any(x => x.Category == category))
            {
                return $"{category} star hotel is not available in our platform.";
            }

            if (chosenRoom == null)
            {
                return "We cannot offer appropriate room for your request.";
            }

            var currHotel = hotels.All().First(x => x.Rooms.All().Contains(chosenRoom));

            int bookingNum = currHotel.Bookings.All().Count + 1;

            var booking = new Booking(chosenRoom, duration, adults, children, bookingNum);
            currHotel.Bookings.AddNew(booking);

            return $"Booking number {bookingNum} for {currHotel.FullName} hotel is successful!";
        }

        public string HotelReport(string hotelName)
        {
            var currHotel = hotels.Select(hotelName);
            StringBuilder sb = new StringBuilder();
            if (currHotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            bool hasBookings = currHotel.Bookings.All().Any();

            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{currHotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {currHotel.Turnover:F2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hasBookings)
            {
                foreach (var booking in currHotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine();
                }
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (!hotels.All().Any(x => x.Rooms.All().Any(x => x.GetType().Name == roomTypeName)))
            {
                return "Room type is not created yet!";
            }

            IRoom room = null;

            switch (roomTypeName)
            {
                case ("Apartment")
                    :
                    room = new Apartment();
                    break;
                case ("Studio")
                    :
                    room = new Studio();
                    break;
                case ("DoubleBed")
                    :
                    room = new DoubleBed();
                    break;
                default:
                    throw new ArgumentException("Incorrect room type!");
            }

            var hotel = hotels.All().First(x => x.FullName == hotelName);

            room = hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException("Price is already set!");
            }

            room.SetPrice(price);
            return $"Price of {roomTypeName} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(x => x.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            var hotel = hotels.Select(hotelName);


            if (hotel.Rooms.All().Any(x => x.GetType().Name == roomTypeName))
            {
                return "Room type is already created!";
            }

            IRoom room = null;

            switch (roomTypeName)
            {
                case ("Apartment")
                    : room = new Apartment();
                    break;
                case ("Studio")
                    :
                    room = new Studio();
                    break;
                case ("DoubleBed")
                    :
                    room = new DoubleBed();
                    break;
                    default: 
                    throw new ArgumentException("Incorrect room type!");
            }

            hotel.Rooms.AddNew(room);
            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
