namespace Cinema_Booking.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public List<string> SubImages { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public List<ShowTime> ShowTime { get; set; }
        public List<Booking> Booking { get; set; }

        public List<MovieActor> MovieActor { get; set; }

    }
}
