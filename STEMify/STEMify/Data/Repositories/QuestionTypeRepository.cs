using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class QuestionTypeRepository : Repository<QuestionType>, IQuestionTypeRepository
    {
        public QuestionTypeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddOptionAsync(QuestionType option)
        {
            _context.Set<QuestionType>().Add(option); // Use DbContext.Set<T>() to access the DbSet  
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<QuestionType>> GetOptionsByQuestionIdAsync(int questionId)
        {
            return await _context.Set<QuestionType>() // Use DbContext.Set<T>() to access the DbSet  
                .Where(o => o.Id == questionId)
                .ToListAsync();
        }
    }
}
