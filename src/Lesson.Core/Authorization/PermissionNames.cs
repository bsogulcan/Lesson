namespace Lesson.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Roles = "Pages.Roles";

        #region Category
        public const string Category_Categories = "Category.Categories";
        public const string Category_AddCategory = "Category.AddCategory";
        public const string Category_UpdateCategory = "Category.UpdateCategory";
        public const string Category_DeleteCategory = "Category.DeleteCategory";
        #endregion

        #region ClassRoom
        public const string ClassRoom = "ClassRoom";
        public const string ClassRoom_Create = "ClassRoom.Create";
        public const string ClassRoom_Get = "ClassRoom.Get";
        public const string ClassRoom_GetList = "ClassRoom.GetList";
        public const string ClassRoom_Update = "ClassRoom.Update";
        public const string ClassRoom_Delete = "ClassRoom.Delete";
        #endregion

    }
}