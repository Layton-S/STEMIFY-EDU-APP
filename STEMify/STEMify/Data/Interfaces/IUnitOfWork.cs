using System;
using System.Threading.Tasks;

namespace STEMify.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        Task CompleteAsync();

        // Add this line to include the Tests property
        //ITestRepository Tests { get; }
        ICourseRepository Courses { get; }
        ICategoryRepository Categories { get; }
        IDifficultyLevelRepository DifficultyLevels { get; }

    }
}