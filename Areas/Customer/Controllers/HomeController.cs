
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema_Booking.Data;
using Cinema_Booking.Models;

namespace Cinema_Booking.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Category).Include(m => m.Cinema).AsQueryable();
            return View(movies.ToList());

        }

        [HttpGet]
        public IActionResult FillInfo(int id)
        {
            ViewBag.MovieId = id;

            ViewBag.ShowTimes = _context.ShowTimes
                .Where(s => s.MovieId == id)
                .ToList();

            return View();
        }


        [HttpPost]
        public IActionResult Create(string name, string phone, int showTimeId)
        {
            var customer = new Client()
            {
                Name = name,
                Phone = phone
            };

            _context.Clients.Add(customer);
            _context.SaveChanges();

            var showTime = _context.ShowTimes
                .FirstOrDefault(s => s.Id == showTimeId);

            if (showTime == null)
                return BadRequest();

            Booking booking = new Booking()
            {
                ClientId = customer.Id,
                ShowTimeId = showTimeId,
                
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ShowAllBookings()
        {
            var bookings = _context.Bookings
                .Include(b => b.ShowTime)
                    .ThenInclude(st => st.Movie)
                        .ThenInclude(m => m.Cinema)

                .Include(b => b.ShowTime.Movie.Category)

                .Include(b => b.Client)
                .ToList();

            return View(bookings);
        }
    }
}

