using System.ComponentModel.DataAnnotations;

namespace Cinema_Booking.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public string? EmailConfirmationToken { get; set; }
        public string? ResetOtp { get; set; }

        public DateTime? OtpExpiry { get; set; }

    }
}
