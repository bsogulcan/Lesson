using Abp.AutoMapper;
using Abp.Runtime.Security;
using AutoMapper;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain;
using Lesson.Domain.Lessons;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using Lesson.Domain.RollCallDetails;
using Lesson.Domain.RollCallDetails.Dto;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCalls.Dto;
using Lesson.Domain.StudentsOfClassRoom;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using Lesson.Web.Models.RollCalls;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class RollCallsController : Controller
    {
        private readonly IRollCallApplicationService _rollCallApplicationService;
        private readonly IClassRoomAppService _classRoomAppService;
        private readonly ILessonOfClassRoomApplicationService _lessonOfClassRoomApplicationService;
        private readonly UserManager _userManager;
        public readonly IStudentOfClassRoomApplicationService _studentOfClassRoomApplicationService;
        private readonly IRollCallDetailApplicationService _rollCallDetailApplicationService;

        public RollCallsController(IRollCallApplicationService rollCallApplicationService,
            IClassRoomAppService classRoomAppService,
            ILessonOfClassRoomApplicationService lessonOfClassRoomApplicationService,
            UserManager userManager,
            IStudentOfClassRoomApplicationService studentOfClassRoomApplicationService,
            IRollCallDetailApplicationService rollCallDetailApplicationService)
        {
            _rollCallApplicationService = rollCallApplicationService;
            _classRoomAppService = classRoomAppService;
            _lessonOfClassRoomApplicationService = lessonOfClassRoomApplicationService;
            _userManager = userManager;
            _studentOfClassRoomApplicationService = studentOfClassRoomApplicationService;
            _rollCallDetailApplicationService = rollCallDetailApplicationService;
        }
        public async Task<ActionResult> Index()
        {
            var rollCalls = await _rollCallApplicationService.GetListAsync();
            return View(rollCalls);
        }
        public async Task<ActionResult> CreateRollCall(RollCallViewModel model)
        {
            model.SessionList = new List<int>();
            for (int i = 1; i <= 10; i++)
                model.SessionList.Add(i);

            //model.Session = 1;

            List<LessonFullOutPut> lessonOfClassFullOutPut = new List<LessonFullOutPut>();
            var classRooms = await _classRoomAppService.GetListAsync();
            if (model.ClassRoomId == 0)
                model.ClassRoomId = classRooms.FirstOrDefault().Id;

            var lessonsOfClass = await _lessonOfClassRoomApplicationService.GetListLessonsOfClassRoom(new Domain.LessonsOfClassRoom.Dto.GetLessonOfClassRoomInput { ClassRoomId = model.ClassRoomId });
            lessonsOfClass.ForEach(x => lessonOfClassFullOutPut.Add(new LessonFullOutPut { Name = x.Lesson.Name, Id = x.Lesson.Id }));

            model.ClassRooms = classRooms;
            model.Lessons = lessonOfClassFullOutPut;

            if (model.LessonId == 0 && model.Lessons.Count > 0)
                model.LessonId = lessonOfClassFullOutPut.FirstOrDefault().Id;

            return View("CreateRollCall", model);
        }

        public async Task<ActionResult> InsertRollCall(RollCallViewModel model)
        {
            var rollCall = await _rollCallApplicationService.CreateAsync(
                new CreateRollCallInput
                {
                    ClassRoomId = model.ClassRoomId,
                    Session = model.Session,
                    LessonId = model.LessonId,
                    User = _userManager.GetUserById(User.Identity.GetUserId<long>()),
                    Date = DateTime.Now
                });

            model.RollCallId = rollCall.Id;
            var studentsOfClassRoom = await _studentOfClassRoomApplicationService.GetAsync(new GetStudentsOfClassRoomInput { ClassRoomId = model.ClassRoomId });

            foreach (var student in studentsOfClassRoom)
            {
                await _rollCallDetailApplicationService.CreateAsync(new Domain.RollCallDetails.Dto.CreateRollCallDetailInput
                {
                    RollCall = await _rollCallApplicationService.GetAsync(new GetRollCallInput { Id = rollCall.Id }),
                    RollCallType = RollCallType.Here,
                    User = _userManager.GetUserById(student.User.Id)
                });
            }

            var rollCallDetails = await _rollCallDetailApplicationService.GetByRollCallIdAsync(
                new Domain.RollCallDetails.Dto.GetRollCallDetailInput
                {
                    RollCall = await _rollCallApplicationService.GetAsync(new GetRollCallInput { Id = rollCall.Id })
                });

            model.Students = new List<RollCallStudentViewModel>();
            foreach (var student in rollCallDetails)
            {
                model.Students.Add(
                    new RollCallStudentViewModel
                    {
                        RollCallDetailId = student.Id,
                        User = _userManager.GetUserById(student.User.Id)
                    }) ;
            }

            return RedirectToAction("Students", new RollCallViewModel { RollCallId = model.RollCallId });
        }

        public async Task<ActionResult> Students(RollCallViewModel model)
        {
            model.Students = new List<RollCallStudentViewModel>();
             
            var rollCallDetails = await _rollCallDetailApplicationService.GetByRollCallIdAsync(
                new Domain.RollCallDetails.Dto.GetRollCallDetailInput
                {
                    RollCall = await _rollCallApplicationService.GetAsync(new GetRollCallInput { Id = model.RollCallId })
                });

            foreach (var rollCall in rollCallDetails)
            {
                model.Students.Add(
                    new RollCallStudentViewModel
                    {
                        RollCallDetailId= rollCall.Id,
                        RollCallType = rollCall.RollCallType,
                        User = rollCall.User
                    });
            }
            return View("Students", model);
        }

        public async Task<ActionResult> UpdateStudentRollCallStatus(RollCallStudentViewModel model)
        {
            await _rollCallDetailApplicationService.UpdateRollCallTypeAsync(new UpdateRollCallDetailInput { Id=model.RollCallDetailId,RollCallType=model.RollCallType});
           
            return RedirectToAction("Students", new RollCallViewModel { RollCallId = model.RollCallId });
        }



    }
}