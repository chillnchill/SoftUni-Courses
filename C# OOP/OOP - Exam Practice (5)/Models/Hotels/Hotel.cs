using BookingApp.Models.Bookings.Contracts;
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

namespace BookingApp.Models.Hotels
{

    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private readonly IRepository<IBooking> bookings;
        private readonly IRepository<IRoom> rooms;
        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            bookings = new BookingRepository();
            rooms = new RoomRepository();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.HotelNameNullOrEmpty);
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
                    throw new ArgumentException(ExceptionMessages.InvalidCategory);
                }
                category = value;
            }
        }

        //get back to the bottom 3 props here:
        public double Turnover
         => Math.Round(Bookings.All().Sum(b => b.ResidenceDuration * b.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms => rooms;

        public IRepository<IBooking> Bookings => bookings;
    }
}
