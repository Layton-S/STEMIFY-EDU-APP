using STEMify.Models;

namespace STEMify.Data.Interfaces
{
    public interface IQuestionTypeRepository : IRepository<QuestionType>
    {
        Task AddOptionAsync(QuestionType option);
        Task<IEnumerable<QuestionType>> GetOptionsByQuestionIdAsync(int questionId);
    }
}
