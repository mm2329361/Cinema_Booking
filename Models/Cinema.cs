namespace Cinema_Booking.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Movie> Movie { get; set; }

    }
}
