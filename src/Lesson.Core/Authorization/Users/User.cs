using System;
using System.Collections.Generic;
using Abp.Authorization.Users;
using Abp.Extensions;
using Lesson.Authorization.Roles;
using Lesson.Classes;
using Microsoft.AspNet.Identity;

namespace Lesson.Authorization.Users
{
    public class User : AbpUser<User>
    {
        public const string DefaultPassword = "123qwe";

        public User()
        {

        }
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            var user = new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };

            user.SetNormalizedNames();

            return user;
        }  
        //public virtual ICollection<Lesson.Domain.Lessons.Lesson> Lessons { get; set; }
        //public ICollection<ClassRoom> ClassRooms { get; set; }
    }
}