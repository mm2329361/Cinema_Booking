using Cinema_Booking.Models;

namespace Cinema_Booking.Services.Interfaces
{
    public interface IBookingService
    {
        List<ShowTime> GetMovieShowTimes(int movieId);

        void CreateBooking(string name, string phone, int showTimeId);

        List<Booking> GetAllBookings();
    }
}