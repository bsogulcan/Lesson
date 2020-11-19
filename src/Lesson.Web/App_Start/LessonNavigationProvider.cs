using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using Lesson.Authorization;
using System.Web;

namespace Lesson.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See Views/Layout/_TopMenu.cshtml file to know how to render menu.
    /// </summary>
    public class LessonNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {

            #region Home Page
            context.Manager.MainMenu.AddItem(new MenuItemDefinition(PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "home",
                        requiresAuthentication: true));
            #endregion
            #region Definitions
            context.Manager.MainMenu.AddItem(new MenuItemDefinition(
                        PageNames.Definitions,
                        L("Definitions"),
                        icon: "chrome_reader_mode"
                 ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users"
                    )).AddItem(new MenuItemDefinition(
                        PageNames.ClassRooms,
                        L("ClassRooms"),
                        url: "ClassRooms"
                 )).AddItem(new MenuItemDefinition(
                        PageNames.Lessons,
                        L("Lessons"),
                        url: "Lessons"
                    )).AddItem(new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants"
                    )));
            #endregion
            #region My Lessons
            context.Manager.MainMenu.AddItem(new MenuItemDefinition("MyLessons",
                        L("MyLessons"),
                        url: "Lessons/MyLessons",
                        icon: "library_books",
                        requiresAuthentication: true));
            #endregion
            #region My HomeWorks
            context.Manager.MainMenu.AddItem(new MenuItemDefinition("HomeWorks",
                        L("MyHomeWorks"),
                        url: "Homeworks",
                        icon: "games",
                        requiresAuthentication: true));
            #endregion
            #region My Exams
            context.Manager.MainMenu.AddItem(new MenuItemDefinition("Exams",
                        L("MyExams"),
                        url: "Exams",
                        icon: "extension",
                        requiresAuthentication: true));
            #endregion
            #region Roll Call
            context.Manager.MainMenu.AddItem(new MenuItemDefinition(PageNames.RollCalls,
                        L("RollCall"),
                        url: "RollCalls",
                        icon: "gavel",
                        requiresAuthentication: true));
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, LessonConsts.LocalizationSourceName);
        }
    }
}
