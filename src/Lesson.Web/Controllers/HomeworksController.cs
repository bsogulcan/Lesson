using Abp.Authorization;
using Lesson.Authorization;
using Lesson.Classes;
using Lesson.Domain.Homeworks;
using Lesson.Domain.Homeworks.Dto;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.SubmittedHomeworks;
using Lesson.Domain.SubmittedHomeworks.Dto;
using Lesson.Domain.VideoContent;
using Lesson.Domain.VideoContent.Dto;
using Lesson.Web.Models.Homeworks;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class HomeworksController : Controller
    {
        private readonly IHomeworkApplicationService _homeworkApplicationService;
        private readonly IClassRoomAppService _classRoomAppService;
        private readonly ILessonOfClassRoomApplicationService _lessonOfClassRoomApplicationService;
        private readonly ISubmittedHomeworksApplicationService _submittedHomeworksApplicationService;
        private readonly IVideoContentApplicationService _videoContentApplicationService;
        public HomeworksController(IHomeworkApplicationService homeworkApplicationService,
            IClassRoomAppService classRoomAppService,
            ILessonOfClassRoomApplicationService lessonOfClassRoomApplicationService,
            ISubmittedHomeworksApplicationService submittedHomeworksApplicationService,
            IVideoContentApplicationService videoContentApplicationService)
        {
            _homeworkApplicationService = homeworkApplicationService;
            _classRoomAppService = classRoomAppService;
            _lessonOfClassRoomApplicationService = lessonOfClassRoomApplicationService;
            _submittedHomeworksApplicationService = submittedHomeworksApplicationService;
            _videoContentApplicationService = videoContentApplicationService;
        }

        // GET: Homeworks
        public async Task<ActionResult> Index()
        {
            await _homeworkApplicationService.Subscribe_Homeworks(User.Identity.GetUserId<long>());

            var homeworks = await _homeworkApplicationService.GetListAsync();
            return View(homeworks);
        }

        [AbpAuthorize(PermissionNames.Pages_HomeWorks_Create)]
        public async Task<ActionResult> CreateHomeWork(HomeworkViewModel model)
        {
            var lessonOfClassFullOutPut = new List<LessonFullOutPut>();

            if (model.Summary == null)
                model.Summary = string.Empty;
            if (model.Description == null)
                model.Description = string.Empty;

            var classRooms = await _classRoomAppService.GetListAsync();
            if (model.ClassRoomId == 0)
                model.ClassRoomId = classRooms.FirstOrDefault().Id;

            var lessonsOfClass = await _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoom(new Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput { ClassRoomId = model.ClassRoomId });
            //lessonsOfClass.ForEach(x => lessonOfClassFullOutPut.Add(new LessonFullOutPut { Name = x.Lesson.Name, Id = x.Lesson.Id }));
            model.ClassRooms = classRooms;
            model.Lessons = lessonsOfClass;

            return View("CreateHomeWork", model);
        }

        public async Task<ActionResult> HomeworkDetail(GetHomeworkInput input)
        {
            var homework = await _homeworkApplicationService.GetAsync(input);

            var getVideoContentInput = new GetVideoContentInput
            {
                HomeworkId = input.Id
            }; 
            homework.VideoContent = _videoContentApplicationService.GetVideoContentByHomeworkId(getVideoContentInput);
            return View("HomeworkDetail", homework);
        }

        //[AbpAuthorize(PermissionNames.Pages_HomeWorks_Create)]
        public async Task<JsonResult> InsertHomeWorkAsync(HomeworkViewModel model)
        { 
            var homework = new CreateHomeworkInput
            {
                ClassRoom = new Classes.Dto.ClassRoomFullOutPut { Id = model.ClassRoomId },
                Lesson = new LessonFullOutPut { Id = model.LessonId },
                Description = model.Description,
                Summary = model.Summary,
                Deadline = model.Deadline, 
                User = new Users.Dto.UserPartOutput
                {
                    Id = User.Identity.GetUserId<long>()
                }
            };

            var createdHomeworkModel = await _homeworkApplicationService.CreateAsync(homework);
 
            var createVideoContentInput = new CreateVideoContentInput();
            if (model.VideoContent != null)
            {
                createVideoContentInput.HomeWorkId = createdHomeworkModel.Id;
                createVideoContentInput.Summary = model.VideoContent.Summary;
                createVideoContentInput.VideoSize = model.VideoContent.VideoSize;
                createVideoContentInput.VideoName = model.VideoContent.VideoName;
                createVideoContentInput.FileBase64 = model.VideoContent.FileBase64;
                createVideoContentInput.Content = Convert.FromBase64String(model.VideoContent.FileBase64);
            }
            await _videoContentApplicationService.CreateAsync(createVideoContentInput);

            return Json(new { HomeworkId = createdHomeworkModel.Id });
        }

        public async Task<JsonResult> SubmiteHomework(CreateSubmittedHomeworkInput input)
        {
            input.File = Convert.FromBase64String(input.FileBase64);
            input.UserId = User.Identity.GetUserId<long>();

            await _submittedHomeworksApplicationService.CreateAsync(input);
            return Json(new { success = true });
        }

        public async Task<ActionResult> SubmittedHomeworks(GetHomeworkInput input)
        {
            var homework = await _homeworkApplicationService.GetAsync(input);
            var getVideoContentInput = new GetVideoContentInput
            {
                HomeworkId = input.Id
            };
            homework.VideoContent = _videoContentApplicationService.GetVideoContentByHomeworkId(getVideoContentInput);

            //var getSubmittedHomeworkInput = new GetSubmittedHomeworkInput
            //{
            //    HomeworkId = input.Id
            //};

            //homework.SubmittedHomeworks = _submittedHomeworksApplicationService.GetByHomework(getSubmittedHomeworkInput);

            return View("SubmittedHomeworks", homework);
        }

        public async Task<FileResult> HomeworkDownloadAsync(GetSubmittedHomeworkInput input)
        {
            var submittedHomework = await _submittedHomeworksApplicationService.GetAsync(input);
            return File(submittedHomework.File, submittedHomework.Type, submittedHomework.Name);
        }

    }
}