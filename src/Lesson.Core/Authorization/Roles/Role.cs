using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Lesson.Authorization.Users;

namespace Lesson.Authorization.Roles
{
    public class Role : AbpRole<User>
    {
        public const int MaxDescriptionLength = 5000;

        public Role()
        {
        }

        public Role(int? tenantId, string displayName)
            : base(tenantId, displayName)
        {

        }

        public Role(int? tenantId, string name, string displayName)
            : base(tenantId, name, displayName)
        {

        }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        //public ICollection<UserRole> Users { get; set; }
    }
}