using STEMify.Models;
using System.Linq.Expressions;

namespace STEMify.Data.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetAllWithIncludes(params Expression<Func<Course, object>>[] includes);

    }
}
