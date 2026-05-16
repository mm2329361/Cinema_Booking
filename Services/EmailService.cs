using System.Net;
using System.Net.Mail;

namespace Cinema_Booking.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var fromEmail = "YOUR_EMAIL@gmail.com";
            var password = "xydymyutagmpttyh";

            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail, password)
            };

            var message = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
                BodyEncoding = System.Text.Encoding.UTF8,
                SubjectEncoding = System.Text.Encoding.UTF8
            };

            message.To.Add(toEmail);

            await smtp.SendMailAsync(message);
            Console.WriteLine("EMAIL SENT SUCCESSFULLY");
        }
    }
}
