using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Lesson.EntityFramework;

namespace Lesson.Migrator
{
    [DependsOn(typeof(LessonDataModule))]
    public class LessonMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<LessonDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}