using STEMify.Data.Interfaces;
using STEMify.Models.User;
using System.Linq;
using System.Linq.Expressions;

namespace STEMify.Data.Repositories
{
    public class UserTaskRepository : Repository<UserTask>, IUserTaskRepository
    {
        private readonly AppDbContext _context;

        public UserTaskRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<UserTask> Get(Expression<Func<UserTask, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public IEnumerable<UserTask> GetUserTasks(string userId)
        {
            return _dbSet.Where(x => x.UserId == userId).ToList();
        }

    }

}
