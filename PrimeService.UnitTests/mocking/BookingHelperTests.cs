using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using PrimeService.mocking;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class BookingHelperTests_OverlappingBookingsExist
    {
        private Booking _existingBooking;
        private Mock<IBookingRepository> _mockBookingRepository;
        [SetUp]
        public void SetUp()
        {
            _existingBooking = new Booking
            {
                Id = 2,
                ArrivalDate = ArriveOn(2017, 1, 15),
                DepartureDate = DepartOn(2017, 1, 20),
                Reference = "a"
            };
            _mockBookingRepository = new Mock<IBookingRepository>();
            _mockBookingRepository.Setup(br => br.GetBookings(1)).Returns(new List<Booking>{
                _existingBooking
            }.AsQueryable());

        }
        [Test]
        public void BookingStatusIsCancelled_ReturnEmptyString()
        {
            var booking = new Booking { Status = "Cancelled" };

            var result = BookingHelper.OverlappingBookingsExist(_mockBookingRepository.Object, booking);

            Assert.That(result, Is.EqualTo(string.Empty));
        }
        [Test]
        public void BookingStartsAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
        {

            var result = BookingHelper.OverlappingBookingsExist(_mockBookingRepository.Object, new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate, days: 2),
                DepartureDate = Before(_existingBooking.ArrivalDate),
            });

            Assert.That(result, Is.EqualTo(string.Empty));
        }
         [Test]
        public void BookingStartsBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(_mockBookingRepository.Object, new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.ArrivalDate),
            });

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        [Test]
        public void BookingStartsBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
        {

            var result = BookingHelper.OverlappingBookingsExist(_mockBookingRepository.Object, new Booking
            {
                Id = 1,
                ArrivalDate = Before(_existingBooking.ArrivalDate),
                DepartureDate = After(_existingBooking.DepartureDate),
            });

            Assert.That(result, Is.EqualTo(_existingBooking.Reference));
        }
        private DateTime ArriveOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 14, 0, 0);
        }
        private DateTime DepartOn(int year, int month, int day)
        {
            return new DateTime(year, month, day, 10, 0, 0);
        }
        private DateTime Before(DateTime dateTime, int days = 1)
        {
            return dateTime.AddDays(-days);
        }
        private DateTime After(DateTime dateTime)
        {
            return dateTime.AddDays(1);
        }
    }
}