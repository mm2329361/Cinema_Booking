
using Cinema_Booking.Data;
using Cinema_Booking.Models;
using Cinema_Booking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema_Booking.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IMovieService _movieService;

        public HomeController(
            IBookingService bookingService,
            IMovieService movieService
        )
        {
            _bookingService = bookingService;
            _movieService = movieService;
        }
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return View(movies);

        }

        [HttpGet]
        public IActionResult FillInfo(int id)
        {
            ViewBag.MovieId = id;

            ViewBag.ShowTimes = _bookingService.GetMovieShowTimes(id);

            return View();
        }


        [HttpPost]
        public IActionResult Create(string name, string phone, int showTimeId)
        {
            try
            {
                _bookingService.CreateBooking(name, phone, showTimeId);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            
        }

        public IActionResult ShowAllBookings()
        {
            var bookings = _bookingService.GetAllBookings();

            return View(bookings);
        }
    }
}

