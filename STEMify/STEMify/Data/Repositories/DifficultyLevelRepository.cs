using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class DifficultyLevelRepository : Repository<DifficultyLevel>, IDifficultyLevelRepository
    {
        public DifficultyLevelRepository(AppDbContext context) : base(context) { }
    }
}
