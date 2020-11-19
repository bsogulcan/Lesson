using Lesson.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Lesson.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly LessonDbContext _context;

        public InitialHostDbBuilder(LessonDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
