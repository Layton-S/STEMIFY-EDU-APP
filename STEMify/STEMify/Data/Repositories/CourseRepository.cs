using STEMify.Models;
using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Data.Repositories;
using STEMify.Data;

namespace STEMify.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
