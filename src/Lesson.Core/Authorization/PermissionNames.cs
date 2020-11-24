namespace Lesson.Authorization
{
    public static class PermissionNames
    {
        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Users = "Pages.Users";
        public const string Pages_Roles = "Pages.Roles";

        #region Definitions
        public const string Pages_Definitions = "Pages.Definitions";
        #endregion

        #region Lessons
        public const string Pages_Lessons = "Pages.Lessons";
        #endregion

        #region HomeWorks
        public const string Pages_HomeWorks = "Pages.HomeWorks";
        public const string Pages_HomeWorks_Create = "Pages.HomeWorks_Create";
        #endregion

        #region Exams
        public const string Pages_Exams = "Pages.Exams";
        public const string Pages_Exams_Create = "Pages.Exams_Create";
        #endregion
        
        #region RollCalls
        public const string Pages_RollCalls = "Pages.RollCalls";
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