using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels;
        private readonly IRepository<IRoom> rooms;
        private readonly IRepository<IBooking> bookings;
        public Controller()
        {
            hotels = new HotelRepository();
            rooms = new RoomRepository();
            bookings = new BookingRepository();
        }
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = hotels.All().FirstOrDefault(n => n.FullName == hotelName);

            if (hotel != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IHotel hotel = hotels.All().FirstOrDefault(c => c.Category == category);

            int totalGuests = children + adults;

            if (hotel == null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            var orderedHotels = hotels.All().Where(c => c.Category == category)
                .OrderBy(n => n.FullName);


            foreach (var rooms in orderedHotels)
            {
                IRoom room = rooms.Rooms.All()
                   .Where(p => p.PricePerNight > 0)
                   .OrderBy(r => r.BedCapacity)
                   .FirstOrDefault(r => r.BedCapacity >= totalGuests);

                if (room != null)
                {
                    int bookingNum = hotel.Bookings.All().Count + 1;
                    IBooking booking = new Booking(room, duration, adults, children, bookingNum);

                    hotel.Bookings.AddNew(booking);

                    return string.Format(OutputMessages.BookingSuccessful, bookingNum, hotel.FullName);
                }

            }

            return string.Format(OutputMessages.RoomNotAppropriate);

        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(n => n.FullName == hotelName);
            List<IBooking> bookings = hotel.Bookings.All().ToList();


            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Hotel name: {hotel.FullName}");
            result.AppendLine($"--{hotel.Category} star hotel");
            result.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            result.AppendLine($"--Bookings:");
            result.AppendLine();

            if (bookings.Count > 0)
            {
                foreach (var booking in bookings)
                {
                    result.AppendLine($"{booking.BookingSummary()}");
                    result.AppendLine();
                }
            }
            else
            {
                result.AppendLine($"none");
            }


            return result.ToString().TrimEnd();

        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.All().FirstOrDefault(n => n.FullName == hotelName);
            var room = hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName);
            string[] correctRoomNames = { "Apartment", "DoubleBed", "Studio" };
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (!correctRoomNames.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (room == null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            if (hotel.Rooms.Select(roomTypeName).PricePerNight != 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            else
            {
                hotel.Rooms.Select(roomTypeName).SetPrice(price);
                return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
            }

        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(n => n.FullName == hotelName);
            IRoom room = rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (room != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();

            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }
    }
}
