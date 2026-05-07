namespace Cinema_Booking.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ShowTimeId { get; set; }
        public ShowTime ShowTime { get; set; }
    }
}
