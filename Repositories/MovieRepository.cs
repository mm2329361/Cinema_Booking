using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Cinema_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Cinema_Booking.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetAllAsync() 
        {
            return await _context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .ToListAsync();
        }
    }
}