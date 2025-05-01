using STEMify.Models;

namespace STEMify.Data.Interfaces
{
    public interface IQuizResultRepository : IRepository<QuizResult>
    {
        Task AddResultAsync(QuizResult result);
        Task<IEnumerable<QuizResult>> GetResultsByUserAsync(int userId);
    }
}
