using Cinema_Booking.Models;

namespace Cinema_Booking.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<Movie>> GetAllMoviesAsync();
    }
}