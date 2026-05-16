using Cinema_Booking.Data;
using Cinema_Booking.Services.Interfaces;
using Cinema_Booking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Area("Identity")]
public class HomeController : Controller
{
    private readonly IAuthService _authService;
    private readonly ApplicationDbContext _context;

    public HomeController(IAuthService authService,
                          ApplicationDbContext context)
    {
        _authService = authService;
        _context = context;
    }

    // ================= REGISTER =================
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(ClientVM client)
    {
        if (!ModelState.IsValid)
            return View(client);

        var result = await _authService.RegisterAsync(client);

        if (!result)
        {
            ModelState.AddModelError("", "Email already exists");
            return View(client);
        }

        TempData["Success"] = "Check your email to confirm account";
        return RedirectToAction("Login");
    }

    // ================= LOGIN =================
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM user)
    {
        if (!ModelState.IsValid)
            return View(user);

        var result = await _authService.LoginAsync(user);

        if (!result)
        {
            ModelState.AddModelError("", "Invalid email or not confirmed");
            return View(user);
        }

        return RedirectToAction("Index", "Home", new { area = "Customer" });
    }

    // ================= CONFIRM EMAIL =================
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string token)
    {
        if (string.IsNullOrEmpty(token))
            return BadRequest();

        var user = await _context.Clients
            .FirstOrDefaultAsync(x => x.EmailConfirmationToken == token);

        if (user == null)
            return NotFound();

        user.IsEmailConfirmed = true;
        user.EmailConfirmationToken = null;

        await _context.SaveChangesAsync();

        return Content("Email Confirmed Successfully");
    }

    // ================= FORGOT PASSWORD =================
    [HttpGet]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordVM model)
    {
        var result = await _authService.SendResetOtpAsync(model.Email);

        if (!result)
        {
            ModelState.AddModelError("", "Email not found");
            return View(model);
        }

        TempData["Email"] = model.Email;

        return RedirectToAction("ResetPassword");
    }

    // ================= RESET PASSWORD =================
    [HttpGet]
    public IActionResult ResetPassword()
    {
        var email = TempData["Email"]?.ToString();

        if (string.IsNullOrEmpty(email))
            return RedirectToAction("ForgotPassword");

        return View(new ResetPasswordVM
        {
            Email = email
        });
    }

    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var result = await _authService.ResetPasswordAsync(model);

        if (!result)
        {
            ModelState.AddModelError("", "Invalid OTP or expired");
            return View(model);
        }

        TempData["Success"] = "Password reset successfully";
        return RedirectToAction("Login");
    }
}