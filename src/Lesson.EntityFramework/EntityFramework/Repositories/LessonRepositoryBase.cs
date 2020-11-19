using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Lesson.EntityFramework.Repositories
{
    public abstract class LessonRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LessonDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LessonRepositoryBase(IDbContextProvider<LessonDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class LessonRepositoryBase<TEntity> : LessonRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LessonRepositoryBase(IDbContextProvider<LessonDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
