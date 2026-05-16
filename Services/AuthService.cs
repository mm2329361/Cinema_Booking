using Cinema_Booking.Models;
using Cinema_Booking.Services.Interfaces;
using Cinema_Booking.ViewModels;

namespace Cinema_Booking.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly EmailService _emailService;

        public AuthService(IUserRepository userRepo,
                           EmailService emailService)
        {
            _userRepo = userRepo;
            _emailService = emailService;
        }

        public async Task<bool> RegisterAsync(ClientVM client)
        {
            var existingUser =
                await _userRepo.GetByEmailAsync(client.Email);

            if (existingUser != null)
                return false;

            var token = Guid.NewGuid().ToString();

            var user = new Client
            {
                FullName = client.FullName,
                Email = client.Email,
                Password = client.Password,
                Phone = client.Phone,
                EmailConfirmationToken = token
            };

            await _userRepo.AddAsync(user);

            var confirmationLink =
                $"https://localhost:7001/Identity/Home/ConfirmEmail?token={token}";

            await _emailService.SendEmailAsync(
                user.Email,
                "Confirm Your Email",
                $"<h3>Click the link below to confirm your email</h3>" +
                $"<a href='{confirmationLink}'>Confirm Email</a>"
            );

            return true;
        }

        public async Task<bool> LoginAsync(LoginVM user)
        {
            var dbUser =
                await _userRepo.GetByEmailAsync(user.Email);

            if (dbUser == null)
                return false;

            if (!dbUser.IsEmailConfirmed)
                return false;

            if (dbUser.Password != user.Password)
                return false;

            return true;
        }

        public Task<bool> LoginAsync(ClientVM client)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendResetOtpAsync(string email)
        {
            var user = await _userRepo.GetByEmailAsync(email);

            if (user == null)
                return false;

            var otp = new Random().Next(100000, 999999).ToString();

            user.ResetOtp = otp;
            user.OtpExpiry = DateTime.Now.AddMinutes(5);

            await _userRepo.UpdateAsync(user);

            await _emailService.SendEmailAsync(
                user.Email,
                "Reset Password OTP",
                $"Your OTP is: {otp}"
            );

            return true;
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordVM model)
        {
            var user = await _userRepo.GetByEmailAsync(model.Email);

            if (user == null)
                return false;

            if (user.ResetOtp != model.Otp)
                return false;

            if (user.OtpExpiry < DateTime.Now)
                return false;

            user.Password = model.NewPassword;

            user.ResetOtp = null;
            user.OtpExpiry = null;

            await _userRepo.UpdateAsync(user);

            return true;
        }
    }
}