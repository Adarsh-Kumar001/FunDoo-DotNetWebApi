using FunDooBusiness.Interfaces;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace FunDooBusiness.Services
{
    public class OtpService : IOtpService
    {
        private readonly IEmailOtpRepository _emailOtpRepository;
        private readonly IConfiguration _configuration;

        public OtpService(
            IEmailOtpRepository emailOtpRepository,
            IConfiguration configuration)
        {
            _emailOtpRepository = emailOtpRepository;
            _configuration = configuration;
        }

        // ---------------- GENERATE + SEND OTP ----------------
        public async Task<string> GenerateAndSendOtpAsync(string email, string purpose)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            var emailOtp = new EmailOtp
            {
                Email = email,
                Otp = otp,
                ExpiryTime = DateTime.UtcNow.AddMinutes(5),
                Purpose = purpose
            };

            await _emailOtpRepository.AddAsync(emailOtp);
            await SendEmailAsync(email, otp, purpose);

            return otp;
        }

        // ---------------- VERIFY OTP ----------------
        public async Task<bool> VerifyOtpAsync(string email, string otp, string purpose)
        {
            var storedOtp = await _emailOtpRepository.GetByEmailAndPurposeAsync(email, purpose);
            if (storedOtp == null) return false;

            if (storedOtp.Otp == otp && storedOtp.ExpiryTime > DateTime.UtcNow)
            {
                await _emailOtpRepository.DeleteAsync(storedOtp.Id);
                return true;
            }

            if (storedOtp.ExpiryTime <= DateTime.UtcNow)
                await _emailOtpRepository.DeleteAsync(storedOtp.Id);

            return false;
        }

        // ---------------- SMTP EMAIL ----------------
        private async Task SendEmailAsync(string email, string otp, string purpose)
        {
            try
            {
                var smtpConfig = _configuration.GetSection("Smtp");

                using var smtp = new SmtpClient(
                    smtpConfig["Host"],
                    int.Parse(smtpConfig["Port"]!)
                )
                {
                    EnableSsl = bool.Parse(smtpConfig["EnableSsl"]!),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(
                        smtpConfig["Email"],
                        smtpConfig["AppPassword"]
                    )
                };

                string subject = purpose == "VERIFY_EMAIL"
                    ? "FunDoo Email Verification OTP"
                    : "FunDoo Password Reset OTP";

                string body = $"Your OTP is {otp}. It expires in 5 minutes.";

                using var message = new MailMessage(
                    smtpConfig["Email"],
                    email,
                    subject,
                    body
                );

                await smtp.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new ApplicationException("Failed to send OTP email", ex);
            }
        }
    }
}
