namespace Cinema_Booking.Models
{
    public class ShowTime
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public List<Booking> Booking { get; set; }

    }
}
