using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class QuizResultRepository : Repository<QuizResult>, IQuizResultRepository
    {
        public QuizResultRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddResultAsync(QuizResult result)
        {
            _context.Set<QuizResult>().Add(result); // Updated to use DbContext.Set<T>()  
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuizResult>> GetResultsByUserAsync(int userId)
        {
            return await _context.Set<QuizResult>() // Updated to use DbContext.Set<T>()  
                .Where(r => r.UserId == userId)
                .ToListAsync();
        }
    }
}
