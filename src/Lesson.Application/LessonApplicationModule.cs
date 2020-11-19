using System.Linq;
using System.Reflection;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Lesson.Authorization.Roles;
using Lesson.Authorization.Users;
using Lesson.Categories;
using Lesson.Categories.Dto;
using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.Classes.Dto;
using Lesson.Manager;
using Lesson.Roles.Dto;
using Lesson.Users.Dto;

namespace Lesson
{
    [DependsOn(typeof(LessonCoreModule), typeof(AbpAutoMapperModule))]
    public class LessonApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);

                cfg.CreateMap<CreateRoleDto, Role>();
                cfg.CreateMap<RoleDto, Role>();
                cfg.CreateMap<Role, RoleDto>().ForMember(x => x.GrantedPermissions,
                    opt => opt.MapFrom(x => x.Permissions.Where(p => p.IsGranted)));

                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<User, UserPartOutput>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
              
                cfg.CreateMap<ClassRoomFullOutPut, ClassRoom>();
                cfg.CreateMap<ClassRoomFullOutPut, ClassRoom>().ForMember(x => x.Id, opt => opt.Ignore());

                MapperManager.DtosToDomain(cfg);

                cfg.AddMaps(typeof(LessonApplicationModule).GetAssembly());
            });
        }
    }
}
