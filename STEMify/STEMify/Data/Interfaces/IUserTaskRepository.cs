using STEMify.Models.User;
using System.Linq.Expressions;

namespace STEMify.Data.Interfaces
{
    public interface IUserTaskRepository : IRepository<UserTask>
    {
        IEnumerable<UserTask> Get(Expression<Func<UserTask, bool>> filter);

        IEnumerable<UserTask> GetUserTasks(string userId);
    }

}
