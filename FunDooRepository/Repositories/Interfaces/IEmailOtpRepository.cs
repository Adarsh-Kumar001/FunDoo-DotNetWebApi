using FunDooRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunDooRepository.Repositories.Interfaces
{
    public interface IEmailOtpRepository
    {
        Task AddAsync(EmailOtp otp);
        Task<EmailOtp?> GetByEmailAndPurposeAsync(string email, string purpose);
        Task DeleteAsync(int id);
    }
}
