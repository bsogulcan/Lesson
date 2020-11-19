using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lesson.Roles.Dto;
using Lesson.Users.Dto;

namespace Lesson.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
        List<UserDto> GetStudents();
        List<UserDto> GetTeachers();
    }
}