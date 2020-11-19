using System.Collections.Generic;
using Lesson.Roles.Dto;
using Lesson.Users.Dto;

namespace Lesson.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}