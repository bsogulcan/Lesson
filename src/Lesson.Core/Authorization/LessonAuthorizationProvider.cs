using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Lesson.Authorization
{
    public class LessonAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);

            //NavigationBar
            context.CreatePermission(PermissionNames.Pages_Definitions, L(PermissionNames.Pages_Definitions));
            context.CreatePermission(PermissionNames.Pages_Lessons, L(PermissionNames.Pages_Lessons));
            context.CreatePermission(PermissionNames.Pages_HomeWorks, L(PermissionNames.Pages_HomeWorks));
            context.CreatePermission(PermissionNames.Pages_HomeWorks_Create, L(PermissionNames.Pages_HomeWorks_Create));

            context.CreatePermission(PermissionNames.Pages_Exams, L(PermissionNames.Pages_Exams));
            context.CreatePermission(PermissionNames.Pages_Exams_Create, L(PermissionNames.Pages_Exams_Create));
            context.CreatePermission(PermissionNames.Pages_RollCalls, L(PermissionNames.Pages_RollCalls));
            context.CreatePermission(PermissionNames.Pages_VideoContents, L(PermissionNames.Pages_VideoContents));
            context.CreatePermission(PermissionNames.Pages_VideoContents_Create, L(PermissionNames.Pages_VideoContents_Create));

            //ClassRoom
            //context.CreatePermission(PermissionNames.ClassRoom, L("Permission_ClassRoom"));
            //context.CreatePermission(PermissionNames.ClassRoom_Create, L("Permission_ClassRoom_Create"));
            //context.CreatePermission(PermissionNames.ClassRoom_Get, L("Permission_ClassRoom_Get"));
            //context.CreatePermission(PermissionNames.ClassRoom_GetList, L("Permission_ClassRoom_GetList"));
            //context.CreatePermission(PermissionNames.ClassRoom_Update, L("Permission_ClassRoom_Update"));
            //context.CreatePermission(PermissionNames.ClassRoom_Delete, L("Permission_ClassRoom_Delete"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LessonConsts.LocalizationSourceName);
        }
    }
}
