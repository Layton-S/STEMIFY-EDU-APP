using STEMify.Models.User;
using STEMify.Data.Interfaces;

namespace STEMify.Data.Repositories
{
    public class UserCoursesRepository : Repository<UserCourses>, IUserCoursesRepository
    {
        public UserCoursesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
