using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Authh;
using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FunDooBusiness.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IOtpService _otpService;

        public AuthService(
            IUserRepository userRepository,
            IConfiguration configuration,
            IOtpService otpService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _otpService = otpService;
        }

        // ---------------- REGISTER ----------------
        public async Task<bool> RegisterAsync(string fullName, string email, string password)
        {
            if (await _userRepository.GetByEmailAsync(email) != null)
                return false;

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                IsEmailVerified = false
            };

            await _userRepository.AddAsync(user);

            // Generate OTP and send via email
            await _otpService.GenerateAndSendOtpAsync(email, "VERIFY_EMAIL");

            return true;
        }

        // ---------------- LOGIN ----------------
        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) || !user.IsEmailVerified)
                return null;

            return GenerateJwtToken(user);
        }

        // ---------------- FORGOT PASSWORD ----------------
        public async Task<bool> ForgotPasswordAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;

            await _otpService.GenerateAndSendOtpAsync(email, "RESET_PASSWORD");

            return true;
        }

        // ---------------- VERIFY EMAIL ----------------
        public async Task<bool> VerifyEmailAsync(string email, string otp)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;

            var isValid = await _otpService.VerifyOtpAsync(email, otp, "VERIFY_EMAIL");
            if (!isValid) return false;

            user.IsEmailVerified = true;
            await _userRepository.UpdateAsync(user);

            return true;
        }

        // ---------------- RESET PASSWORD ----------------
        public async Task<bool> ResetPasswordAsync(string email, string otp, string newPassword)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return false;

            var validOtp = await _otpService.VerifyOtpAsync(email, otp, "RESET_PASSWORD");
            if (!validOtp) return false;

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _userRepository.UpdateAsync(user);

            return true;
        }

        // ---------------- JWT TOKEN GENERATION ----------------
        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
