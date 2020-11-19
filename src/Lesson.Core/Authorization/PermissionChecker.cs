using Abp.Authorization;
using Lesson.Authorization.Roles;
using Lesson.Authorization.Users;

namespace Lesson.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
