using Lesson.Domain.News;
using Lesson.Domain.News.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsApplicationService _newsApplicationService;

        public NewsController(INewsApplicationService newsApplicationService)
        {
            _newsApplicationService = newsApplicationService;
        }

        // GET: News
        public async Task<ActionResult> Index()
        {
            var news =await _newsApplicationService.GetListAsync();
            return View(news);
        }

        public ActionResult CreateNews(CreateNewsInput input)
        {
            return View("CreateNews", input);
        }

        public async Task<JsonResult> InsertNews(CreateNewsInput input)
        {
            await _newsApplicationService.CreateAsync(input); 
            return Json(new { Succes=true});
        }

        public async Task<JsonResult> UpdateNews(UpdateNewsInput input)
        {
            await _newsApplicationService.UpdateAsync(input); 
            return Json(new { Succes=true});
        }

        public async Task<ActionResult> DetailNews(GetNewsInput input)
        {
            var news = await _newsApplicationService.GetAsync(input);
            return View("DetailNews",news);
        }

        public ActionResult SearchNews(string summary)
        {
            var getNewsInput = new GetNewsInput
            {
                Summary = summary
            };

            var news = _newsApplicationService.Search(getNewsInput);

            return View("SearchNews", news);
        }
    }
}