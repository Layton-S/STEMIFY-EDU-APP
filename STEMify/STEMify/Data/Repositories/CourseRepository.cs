using STEMify.Models;
using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Data.Repositories;
using STEMify.Data;
using System.Linq.Expressions;

namespace STEMify.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAllWithIncludes(params Expression<Func<Course, object>>[] includes)
        {
            IQueryable<Course> query = _context.Courses;

            foreach(var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }

    }
}
