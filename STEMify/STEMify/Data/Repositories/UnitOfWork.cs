using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;

namespace STEMify.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            //Tests = new TestRepository(_context);
        }

        //public ITestRepository Tests { get; private set; }

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