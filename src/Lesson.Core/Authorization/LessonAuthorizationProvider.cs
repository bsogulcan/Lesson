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

            context.CreatePermission(PermissionNames.Category_Categories, L(PermissionNames.Category_Categories));
            context.CreatePermission(PermissionNames.Category_AddCategory, L(PermissionNames.Category_AddCategory));
            context.CreatePermission(PermissionNames.Category_UpdateCategory, L(PermissionNames.Category_UpdateCategory));
            context.CreatePermission(PermissionNames.Category_DeleteCategory, L(PermissionNames.Category_DeleteCategory));

            //ClassRoom
            context.CreatePermission(PermissionNames.ClassRoom, L("Permission_ClassRoom"));
            context.CreatePermission(PermissionNames.ClassRoom_Create, L("Permission_ClassRoom_Create"));
            context.CreatePermission(PermissionNames.ClassRoom_Get, L("Permission_ClassRoom_Get"));
            context.CreatePermission(PermissionNames.ClassRoom_GetList, L("Permission_ClassRoom_GetList"));
            context.CreatePermission(PermissionNames.ClassRoom_Update, L("Permission_ClassRoom_Update"));
            context.CreatePermission(PermissionNames.ClassRoom_Delete, L("Permission_ClassRoom_Delete"));

        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LessonConsts.LocalizationSourceName);
        }
    }
}
