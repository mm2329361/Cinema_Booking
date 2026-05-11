using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Cinema_Booking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ShowTime> GetMovieShowTimes(int movieId)
        {
            return _context.ShowTimes
                .Where(s => s.MovieId == movieId)
                .ToList();
        }

        public ShowTime? GetShowTimeById(int id)
        {
            return _context.ShowTimes
                .FirstOrDefault(s => s.Id == id);
        }

        public void AddClient(Client client)
        {
            _context.Clients.Add(client);
        }

        public void AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
        }

        public List<Booking> GetAllBookings()
        {
            return _context.Bookings
                .Include(b => b.ShowTime)
                    .ThenInclude(st => st.Movie)
                        .ThenInclude(m => m.Cinema)

                .Include(b => b.ShowTime.Movie.Category)

                .Include(b => b.Client)
                .ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
