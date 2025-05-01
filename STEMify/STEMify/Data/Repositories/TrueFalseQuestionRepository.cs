using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class TrueFalseQuestionRepository : Repository<TrueFalseQuestion>, ITrueFalseQuestionRepository
    {
        public TrueFalseQuestionRepository(AppDbContext context) : base(context) { }
    }
}
