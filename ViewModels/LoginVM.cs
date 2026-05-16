using System.ComponentModel.DataAnnotations;

namespace Cinema_Booking.ViewModels
{
    public class LoginVM
    {
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
