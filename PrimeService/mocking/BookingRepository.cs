using System.Linq;
using TestNinja.Mocking;

namespace PrimeService.mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings(Booking booking);
    }

    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetBookings(Booking booking)
        {
            var unitOfWork = new UnitOfWork();

            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Id != booking.Id && b.Status != "Cancelled");
            return bookings;
        }
    }
}