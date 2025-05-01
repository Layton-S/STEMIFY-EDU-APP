using System.Linq.Expressions;

namespace STEMify.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id); // Find an entity by its ID
        Task<IEnumerable<TEntity>> GetAllAsync(); // Get all entities
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate); // Find entities based on a condition

        Task AddAsync(TEntity entity); // Add a new entity
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
    }
}
