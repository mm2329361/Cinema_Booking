using Cinema_Booking.ViewModels;

namespace Cinema_Booking.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(ClientVM client);
        Task<bool> SendResetOtpAsync(string email);
        Task<bool> ResetPasswordAsync(ResetPasswordVM model);
        Task<bool> LoginAsync(LoginVM user);
    }
}
