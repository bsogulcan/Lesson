using Lesson.Classes;
using Lesson.Domain.Exams;
using Lesson.Domain.Exams.Exam;
using Lesson.Domain.Exams.Exam.Dto;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
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

        public async Task<ActionResult> Index()
        {
            var exams = await _examApplicationService.GetListAsync();

            foreach (var exam in exams)
            {
                exam.Approved = _studentsAnswerOfExamApplicationService.IsUserApprovedExam(
                    new GetStudentsAnswerOfExamInput
                    {
                        UserId = User.Identity.GetUserId<int>(),
                        ExaminationId = exam.Id
                    });
            }

            return View(exams);
        }

        public ActionResult DetailExam(GetExaminationInput input)
        {
            var exam = _examApplicationService.Get(input);
            foreach (var item in exam.Questions)
            {
                var x = item.Answers;
            }
            return View("DetailExam", exam);
        }

        public async Task<ActionResult> CreateExam(ExamViewModel model)
        {
            var classRooms = await _classRoomAppService.GetListAsync();
            if (model.ClassRoomId == 0)
                model.ClassRoomId = classRooms.FirstOrDefault().Id;

            List<LessonFullOutPut> lessonOfClassFullOutPut = new List<LessonFullOutPut>();
            var lessonsOfClass = await _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoom(new Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput { ClassRoomId = model.ClassRoomId });
            lessonsOfClass.ForEach(x => lessonOfClassFullOutPut.Add(new LessonFullOutPut { Name = x.Lesson.Name, Id = x.Lesson.Id }));

            model.Questions = new List<Domain.Exams.ExaminationQuestion>();
            for (int i = 0; i < 10; i++)
            {
                var answers = new List<Domain.Exams.ExaminationQuestionAnswer>();
                for (int z = 0; z < 2; z++)
                    answers.Add(new Domain.Exams.ExaminationQuestionAnswer { });

                model.Questions.Add(new Domain.Exams.ExaminationQuestion { Answers = answers });
            }

            model.ClassRooms = classRooms;
            model.Lessons = lessonOfClassFullOutPut;
            var restul = JsonConvert.SerializeObject(model.Questions);

            return View("CreateExam", model);
        }

        public async Task<JsonResult> InsertExamAsync(CreateExamInput model)
        {
            model.UserId = (int)User.Identity.GetUserId<long>();
            await _examApplicationService.CreateAsync(model);
            return Json(new { success = true });
        }

        public async Task<JsonResult> InsertStudentsAnswer(List<CreateStudentsAnswerOfExamInput> input)
        {
            foreach (var answer in input)
            {
                answer.UserId = (int)User.Identity.GetUserId<long>();
                await _studentsAnswerOfExamApplicationService.CreateAsync(answer);
            }

            return Json(new { success = true });
        }

        public ActionResult ResultOfExams(GetExaminationInput input)
        {
            var exam = _examApplicationService.Get(input);
            int correctAnswerCount = 0;
            int wrongAnswerCount = 0;
            exam.StudentsAnswers = _studentsAnswerOfExamApplicationService.GetAnswersByExam(
                    new GetStudentsAnswerOfExamInput
                    {
                        UserId = (int)exam.User.Id,
                        ExaminationId = exam.Id
                    });

            foreach (var item in exam.Questions)
            {
                var studentsAnswer = exam.StudentsAnswers.Where(m => m.ExaminationQuestion.Id == item.Id).FirstOrDefault();

                if (studentsAnswer != null && studentsAnswer.ExaminationQuestionAnswer.Status)
                    correctAnswerCount++;
                else
                    wrongAnswerCount++;

                exam.CorrectAnswerCount = item.Answers.Where(m => m.Status == true).ToList().Count();
                exam.WrongAnswerCount = item.Answers.Where(m => m.Status == false).ToList().Count();
                exam.AnswerCount = item.Answers.Count();
                var x = item.Answers;
            }

            exam.CorrectAnswerCount = correctAnswerCount;
            exam.WrongAnswerCount = wrongAnswerCount;
            return View("ResultOfExams", exam);
        }
    }
}