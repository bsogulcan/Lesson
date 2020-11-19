using System.Linq;
using Lesson.EntityFramework;
using Lesson.MultiTenancy;

namespace Lesson.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly LessonDbContext _context;

        public DefaultTenantCreator(LessonDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
