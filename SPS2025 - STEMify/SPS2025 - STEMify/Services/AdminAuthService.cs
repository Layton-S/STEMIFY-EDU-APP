using SPS2025___STEMify.Data;
using Microsoft.EntityFrameworkCore;

namespace SPS2025___STEMify.Services
{
    public class AdminAuthService
    {
        private readonly ApplicationDbContext _context;

        public AdminAuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Admin> Authenticate(string username, string password)
        {
            return await _context.Admins
                .FirstOrDefaultAsync(a => a.Username == username && a.Password == password);
        }
    }
}
