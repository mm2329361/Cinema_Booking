using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Cinema_Booking.Repositories.Interfaces;
using Cinema_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cinema_Booking.Repositories.Interfaces;


namespace Cinema_Booking.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }
    }
}