using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration
        {
            get => residenceDuration;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get => adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get => childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                childrenCount = value;
            }
        }

        //unsure, was also unsure of something in "Room":
        public int BookingNumber { get; private set; }

        //see if the totalPaid is right when printing

        public string BookingSummary()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Booking number: {BookingNumber}");
            result.AppendLine($"Room type: {Room.GetType().Name}");
            result.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            result.AppendLine($"Total amount paid: {TotalPaid():f2} $");

            return result.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            double totalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            return totalPaid;
        }
    }
}
