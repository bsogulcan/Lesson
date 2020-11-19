using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class AboutController : LessonControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}