using Microsoft.EntityFrameworkCore;
using STEMify.Data.Interfaces;
using System.Linq.Expressions;

namespace STEMify.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        // Synchronous methods
        public TEntity Get(int id) => _dbSet.Find(id);

        public IEnumerable<TEntity> GetAll() => _dbSet.ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) =>
            _dbSet.Where(predicate).ToList();

        public void Add(TEntity entity) => _dbSet.Add(entity);

        public void Update(TEntity entity) => _context.Entry(entity).State = EntityState.Modified;

        public void Remove(TEntity entity) => _dbSet.Remove(entity);

        // Asynchronous methods
        public async Task<TEntity> GetAsync(int id) => await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await _dbSet.Where(predicate).ToListAsync();

        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
    }
}
