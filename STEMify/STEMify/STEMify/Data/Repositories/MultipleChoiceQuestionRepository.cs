using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class MultipleChoiceQuestionRepository : Repository<MultipleChoiceQuestion> , IMultipleChoiceQuestionRepository
    {
        public MultipleChoiceQuestionRepository(AppDbContext context) : base(context) { }
    }
}
