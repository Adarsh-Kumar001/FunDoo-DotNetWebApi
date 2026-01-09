using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using FunDooModels.DTOs.Authh;

namespace FunDooBusiness.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(string fullName, string email, string password);
        Task<string?> LoginAsync(string email, string password);
        Task<bool> VerifyEmailAsync(string email, string otp);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
    }
}
