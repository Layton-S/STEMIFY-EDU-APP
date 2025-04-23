using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using STEMify.Models;

namespace STEMify.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Categories = new CategoryRepository(_context);
            DifficultyLevels = new DifficultyLevelRepository(_context);
        }

        //public ITestRepository Tests { get; private set; }
        public ICourseRepository Courses { get; private set; }
        public ICategoryRepository Categories { get; private set; }
        public IDifficultyLevelRepository DifficultyLevels { get; private set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}