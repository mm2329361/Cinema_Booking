using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Cinema_Booking.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Cinema_Booking.Repositories.Interfaces;

namespace Cinema_Booking.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public List<ShowTime> GetMovieShowTimes(int movieId)
        {
            return _bookingRepository.GetMovieShowTimes(movieId);
        }

        public void CreateBooking(string name, string phone, int showTimeId)
        {
            var showTime = _bookingRepository
                .GetShowTimeById(showTimeId);

            if (showTime == null)
                throw new Exception("Invalid Show Time");

            var customer = new Client()
            {
                Name = name,
                Phone = phone
            };

            _bookingRepository.AddClient(customer);

            _bookingRepository.Save();

            Booking booking = new Booking()
            {
                ClientId = customer.Id,
                ShowTimeId = showTimeId,
            };

            _bookingRepository.AddBooking(booking);

            _bookingRepository.Save();
        }

        public List<Booking> GetAllBookings()
        {
            return _bookingRepository.GetAllBookings();
        }
    }
}
