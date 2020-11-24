using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using Lesson.Domain.News;

namespace Lesson.Web.Controllers
{
    [AbpMvcAuthorize]

    public class HomeController : LessonControllerBase
    {
        private readonly INewsApplicationService _newsApplicationService;
        public HomeController(INewsApplicationService newsApplicationService)
        {
            _newsApplicationService = newsApplicationService;
        }
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var news = await _newsApplicationService.GetListAsync();
            return View(news);
        }
	}
}