using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Interfaces
{
    public interface IFillInTheBlankQuestionRepository : IRepository<FillInTheBlankQuestion>
    {
    }
}
