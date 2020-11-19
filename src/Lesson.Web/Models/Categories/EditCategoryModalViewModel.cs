using Lesson.Categories.Dto;
using Lesson.Roles.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.Categories
{
    public class EditCategoryModalViewModel:CategoryInput
    {
        public RoleDto Role { get; set; }
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
        public bool HasPermission(PermissionDto permission)
        {
            return Permissions != null && Role.GrantedPermissions.Any(p => p == permission.Name);
        }
    }
}