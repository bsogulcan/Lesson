using Abp.Web.Mvc.Views;

namespace Lesson.Web.Views
{
    public abstract class LessonWebViewPageBase : LessonWebViewPageBase<dynamic>
    {

    }

    public abstract class LessonWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected LessonWebViewPageBase()
        {
            LocalizationSourceName = LessonConsts.LocalizationSourceName;
        }
    }
}