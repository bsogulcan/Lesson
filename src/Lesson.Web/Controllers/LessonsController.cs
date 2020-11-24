using Abp.Domain.Repositories;
using Abp.Runtime.Security;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.Lessons;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using Lesson.Domain.StudentsOfClassRoom;
using Lesson.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Views.Lessons
{
    public class LessonsController : Controller
    {
        private readonly ILessonApplicationService _lessonApplicationService;
        private readonly ILessonOfClassRoomApplicationService _lessonOfClassRoomApplicationService;
        private readonly IClassRoomAppService _classRoomAppService;
        private readonly IUserAppService _userAppService;
        private readonly IStudentOfClassRoomApplicationService _studentOfClassRoomApplicationService;


        public LessonsController(ILessonApplicationService lessonApplicationService, IUserAppService userAppService, ILessonOfClassRoomApplicationService lessonOfClassRoomApplicationService, IClassRoomAppService classRoomAppService, IStudentOfClassRoomApplicationService studentOfClassRoomApplicationService)
        {
            _lessonApplicationService = lessonApplicationService;
            _lessonOfClassRoomApplicationService = lessonOfClassRoomApplicationService;
            _classRoomAppService = classRoomAppService;
            _userAppService = userAppService;
            _studentOfClassRoomApplicationService = studentOfClassRoomApplicationService;
        }
        public async Task<ActionResult> Index()
        {
            var lessons = await _lessonApplicationService.GetListAsync();
            return View(lessons);
        }
        public async Task<ActionResult> EditModal(int id)
        {
            var lesson = await _lessonApplicationService.GetAsync(new Domain.Lessons.Dto.GetLessonInput { Id = id });
            var editModal = new UpdateLessonInput
            {
                Id = id,
                Name = lesson.Name
            };
            return View("_EditModal", editModal);
        }

        public async Task<ActionResult> LessonsOfClassRoom(Lesson.Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput input)
        {
            var lessonsOfClass = _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoomBaseOutPut(new Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput { ClassRoomId = input.ClassRoomId });
            var teachers = _userAppService.GetTeachers();
            var classRooms = await _classRoomAppService.GetListAsync();
            var lessons = await _lessonApplicationService.GetListAsync();

            ViewBag.ClassRoomId = classRooms.Where(x => x.Id == input.ClassRoomId).Select(x =>
                                      new SelectListItem()
                                      {
                                          Value = x.Id.ToString(),
                                          Text = x.Name + " " + x.Branch
                                      });

            ViewBag.UserId = teachers.Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name + " " + x.Surname
                                  });

            ViewBag.LessonId = lessons.Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name
                                  });

            return View("LessonOfClassRoom", lessonsOfClass);
        }
        public async Task<ActionResult> LessonOfClassRoom_EditModal(Lesson.Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput input)
        {
            var lessonsOfClass = await _lessonOfClassRoomApplicationService.GetAsync(new Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput { Id = input.Id });


            var teachers = _userAppService.GetTeachers();
            var classRooms = await _classRoomAppService.GetListAsync();
            var lessons = await _lessonApplicationService.GetListAsync();

            ViewBag.ClassRoomId = classRooms.Where(x => x.Id == lessonsOfClass.ClassRoom.Id).Select(x =>
                                      new SelectListItem()
                                      {
                                          Value = x.Id.ToString(),
                                          Text = x.Name + " " + x.Branch
                                      });

            ViewBag.UserId = teachers.Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name + " " + x.Surname
                                  });

            ViewBag.LessonId = lessons.Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name
                                  });


            var editModal = new UpdateLessonsOfClassRoomInput
            {
                Id = lessonsOfClass.Id,
                ClassRoomId = lessonsOfClass.ClassRoom.Id,
                LessonId = lessonsOfClass.Lesson.Id,
                UserId = lessonsOfClass.User.Id
            };
            return View("LessonOfClassRoom_EditModal", editModal);
        }
        public async Task<ActionResult> MyLessons()
        {
            List<LessonOfClassRoomFullOutPut> myLessons = new List<LessonOfClassRoomFullOutPut>();

            var getLessonOfClassRoomInput = new GetLessonOfClassRoomInput
            {
                UserId = (long)User.Identity.GetUserId()
            };

            var isTeacher = User.IsInRole("Öğretmen");
            if (isTeacher)
            {
                myLessons = _lessonOfClassRoomApplicationService.GetTeacherLessonsOfClassRoom(getLessonOfClassRoomInput);
            }
            else
            {
                var studentsClassRoom = _studentOfClassRoomApplicationService.GetStudentsLessons(getLessonOfClassRoomInput);
                foreach (var classRoom in studentsClassRoom)
                {
                    var lessonsOfClassRoom = _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoomById(classRoom.ClassRoom.Id);
                    myLessons.AddRange(lessonsOfClassRoom);
                };
            }

            return View("MyLessons", myLessons);
        }
    }
}