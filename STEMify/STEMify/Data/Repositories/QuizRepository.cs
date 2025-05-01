using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class QuizRepository : Repository<Quiz>, IQuizRepository
    {
        public QuizRepository(AppDbContext context) : base(context) { }

        public async Task AddQuizAsync(Quiz quiz)
        {
            _context.Set<Quiz>().Add(quiz); // Use DbContext.Set<TEntity>() to access the DbSet
            await _context.SaveChangesAsync();
        }

        public async Task<Quiz> GetQuizByIdAsync(int quizId)
        {
            return await _context.Set<Quiz>().FindAsync(quizId); // Use DbContext.Set<TEntity>() to access the DbSet
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync()
        {
            return await _context.Set<Quiz>().ToListAsync(); // Use DbContext.Set<TEntity>() to access the DbSet
        }
    }
}
