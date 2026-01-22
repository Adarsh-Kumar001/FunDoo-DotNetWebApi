using Microsoft.AspNetCore.Mvc;
using FunDooBusiness.Interfaces;
using FunDooModels.DTOs.Authh;


namespace FunDooWebApi.Controllers
{

    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ---------------- REGISTER ----------------
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO model)
        {
            var result = await _authService.RegisterAsync(
                model.FullName,
                model.Email,
                model.Password
            );

            if (!result)
                return BadRequest(new { message = "User already exists" });

            return Ok(new { message = "User registered successfully" });
        }

        // ---------------- LOGIN ----------------
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            var token = await _authService.LoginAsync(
                model.Email,
                model.Password
            );

            if (string.IsNullOrEmpty(token))
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { token });
        }

        // ---------------- VERIFY EMAIL ----------------
        [HttpPost("verify-email")]
        public async Task<IActionResult> VerifyEmail([FromBody] VerifyEmailDTO dto)
        {
            var result = await _authService.VerifyEmailAsync(dto.Email, dto.Otp);
            if (!result) return BadRequest("Invalid email or OTP");

            return Ok(new { message = "Email verified successfully" });
        }

        // ---------------- FORGOT PASSWORD ----------------
        // Forgot password
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgetPasswordDTO dto)
        {
            var result = await _authService.ForgotPasswordAsync(dto.Email);
            if (!result)
                return BadRequest(new { message = "Email not found" });

            return Ok(new { message = "Password reset OTP sent" });
        }

        // Reset password
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
        {
            var result = await _authService.ResetPasswordAsync(
                dto.Email,
                dto.Otp,
                dto.NewPassword
            );

            if (!result)
                return BadRequest(new { message = "Invalid OTP or email" });

            return Ok(new { message = "Password reset successful" });
        }


    }

}
