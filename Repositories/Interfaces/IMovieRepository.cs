using Cinema_Booking.Models;

namespace Cinema_Booking.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(); 
    }
}