namespace Cinema_Booking.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<MovieActor> MovieActor { get; set; }
    }

}

