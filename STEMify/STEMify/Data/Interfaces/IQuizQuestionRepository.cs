using STEMify.Models;

namespace STEMify.Data.Interfaces
{
    public interface IQuizQuestionRepository : IRepository<QuizQuestion>
    {
        Task AddQuestionAsync(QuizQuestion question);
        Task<QuizQuestion> GetQuestionByIdAsync(int questionId);
        Task<IEnumerable<QuizQuestion>> GetQuestionsByQuizIdAsync(int quizId);
    }
}