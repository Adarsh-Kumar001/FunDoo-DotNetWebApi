using FunDooRepository.Entities;
using FunDooRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using FunDooRepository.DbContextFolder;

namespace FunDooRepository.Repositories.Implementation
{
    public class EmailOtpRepository : IEmailOtpRepository
    {
        private readonly FunDooNotesDbContext _context;

        public EmailOtpRepository(FunDooNotesDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmailOtp otp)
        {
            // Remove old OTPs for same email + purpose
            var existingOtps = _context.EmailOtps
                .Where(o => o.Email == otp.Email && o.Purpose == otp.Purpose);

            _context.EmailOtps.RemoveRange(existingOtps);

            await _context.EmailOtps.AddAsync(otp);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailOtp?> GetByEmailAndPurposeAsync(string email, string purpose)
        {
            return await _context.EmailOtps
                .Where(o => o.Email == email && o.Purpose == purpose)
                .OrderByDescending(o => o.ExpiryTime)
                .FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var otp = await _context.EmailOtps.FindAsync(id);
            if (otp != null)
            {
                _context.EmailOtps.Remove(otp);
                await _context.SaveChangesAsync();
            }
        }
    }
}
