using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Interfaces
{
    public interface IMultipleChoiceQuestionRepository : IRepository<MultipleChoiceQuestion>
    {
    }
}
