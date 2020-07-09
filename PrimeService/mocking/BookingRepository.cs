using System.Linq;
using TestNinja.Mocking;

namespace PrimeService.mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings(int? excludedBookingId = null);
    }

    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetBookings(int?  excludedBookingId = null)
        {
            var unitOfWork = new UnitOfWork();

            var bookings =
                unitOfWork.Query<Booking>()
                    .Where(
                        b => b.Status != "Cancelled");
            if(excludedBookingId.HasValue)
                bookings = bookings.Where(b => b.Id != excludedBookingId.Value);
            return bookings;
        }
    }
}