using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class FillInTheBlankQuestionRepository : Repository<FillInTheBlankQuestion>, IFillInTheBlankQuestionRepository
    {
        public FillInTheBlankQuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
