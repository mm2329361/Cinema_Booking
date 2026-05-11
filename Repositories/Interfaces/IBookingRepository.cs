using Cinema_Booking.Models;

namespace Cinema_Booking.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        List<ShowTime> GetMovieShowTimes(int movieId);

        ShowTime? GetShowTimeById(int id);

        void AddClient(Client client);

        void AddBooking(Booking booking);

        List<Booking> GetAllBookings();

        void Save();
    }
}
