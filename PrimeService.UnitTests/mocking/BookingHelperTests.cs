using Moq;
using NUnit.Framework;
using PrimeService.mocking;
using TestNinja.Mocking;

namespace PrimeService.UnitTests.mocking
{
    [TestFixture]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _mockBookingRepository;
        [SetUp]
        public void SetUp()
        {
            _mockBookingRepository = new Mock<IBookingRepository>();
        }
        [Test]
        public void OverlappingBookingsExist_BookingStatusIsCancelled_ReturnEmptyString()
        {
            var booking = new Booking{Status = "Cancelled"};

            var result = BookingHelper.OverlappingBookingsExist(_mockBookingRepository.Object, booking);

            Assert.That(result, Is.Empty);
        }
    }
}