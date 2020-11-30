using Abp.Authorization;
using Lesson.Authorization;
using Lesson.Classes;
using Lesson.Domain.Exams;
using Lesson.Domain.Exams.Exam;
using Lesson.Domain.Exams.Exam.Dto;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using Lesson.Domain.StudentsAnswersOfExam;
using Lesson.Domain.StudentsAnswersOfExam.Dto;
using Lesson.Manager;
using Lesson.Web.Models.Exams;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class ExamsController : Controller
    {
        private readonly IExamApplicationService _examApplicationService;
        private readonly IClassRoomAppService _classRoomAppService;
        private readonly ILessonOfClassRoomApplicationService _lessonOfClassRoomApplicationService;
        private readonly IEntityManager _entityManager;
        private readonly IStudentsAnswerOfExamApplicationService _studentsAnswerOfExamApplicationService;

        public ExamsController(IClassRoomAppService classRoomAppService,
            ILessonOfClassRoomApplicationService lessonOfClassRoomApplicationService,
            IExamApplicationService examApplicationService,
            IEntityManager entityManager,
            IStudentsAnswerOfExamApplicationService studentsAnswerOfExamApplicationService)
        {
            _classRoomAppService = classRoomAppService;
            _lessonOfClassRoomApplicationService = lessonOfClassRoomApplicationService;
            _examApplicationService = examApplicationService;
            _entityManager = entityManager;
            _studentsAnswerOfExamApplicationService = studentsAnswerOfExamApplicationService;
        }

        [AbpAuthorize(PermissionNames.Pages_Exams)]
        public async Task<ActionResult> Index()
        {
            var exams = await _examApplicationService.GetListAsync();
            ViewBag.UserId = User.Identity.GetUserId<int>();
            //foreach (var exam in exams)
            //{
            //    exam.Approved = _studentsAnswerOfExamApplicationService.IsUserApprovedExam(
            //        new GetStudentsAnswerOfExamInput
            //        {
            //            UserId = User.Identity.GetUserId<int>(),
            //            ExaminationId = exam.Id
            //        });
            //}

            return View(exams);
        }

        public async Task<ActionResult> DetailExam(GetExaminationInput input)
        {
            var exam = await _examApplicationService.GetAsync(input);
            foreach (var item in exam.Questions)
            {
                var x = item.Answers;
            }
            return View("DetailExam", exam);
        }

        [AbpAuthorize(PermissionNames.Pages_Exams_Create)]
        public async Task<ActionResult> CreateExam(ExamViewModel model)
        {
            model.ClassRooms = await _classRoomAppService.GetListAsync();
            if (model.ClassRoomId == 0)
                model.ClassRoomId = model.ClassRooms.FirstOrDefault().Id;

            var lessonOfClassRoomInput = new GetLessonOfClassRoomInput
            {
                ClassRoomId = model.ClassRoomId
            };

            model.Lessons = await _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoom(lessonOfClassRoomInput);
            model.Questions = new List<Domain.Exams.ExaminationQuestion>();              
            return View("CreateExam", model);
        }

        [AbpAuthorize(PermissionNames.Pages_Exams_Create)]
        public async Task<JsonResult> InsertExamAsync(CreateExamInput model)
        {
            model.UserId = User.Identity.GetUserId<long>();
            await _examApplicationService.CreateAsync(model);
            return Json(new { success = true });
        }

        public async Task<JsonResult> InsertStudentsAnswer(List<CreateStudentsAnswerOfExamInput> input)
        { 
            foreach (var answer in input)
            {
                answer.UserId = User.Identity.GetUserId<long>();
                await _studentsAnswerOfExamApplicationService.CreateAsync(answer);
            }

            return Json(new { success = true });
        }

        public async Task<ActionResult> ResultOfExams(GetExaminationInput input)
        {
            var exam = await _examApplicationService.GetAsync(input);

            foreach (var question in exam.Questions)
            {
                var x = question.Answers;
            }

            exam.CorrectAnswerCount = exam.StudentsAnswers.Count(s=>s.ExaminationQuestionAnswer.Status);
            exam.WrongAnswerCount = exam.StudentsAnswers.Count(s => !s.ExaminationQuestionAnswer.Status);
            exam.AnswerCount = exam.StudentsAnswers.Count(); 

            return View("ResultOfExams", exam);
        }
    }
}