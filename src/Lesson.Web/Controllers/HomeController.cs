using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Lesson.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : LessonControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}