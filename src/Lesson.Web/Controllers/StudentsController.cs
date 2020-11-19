using Lesson.Classes;
using Lesson.Domain.StudentsOfClassRoom;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using Lesson.Users;
using Microsoft.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IStudentOfClassRoomApplicationService _studentOfClassRoomApplicationService;
        private readonly IClassRoomAppService _classRoomAppService;

        public StudentsController(IUserAppService userAppService, IStudentOfClassRoomApplicationService studentOfClassRoomApplicationService, IClassRoomAppService classRoomAppService)
        {
            _userAppService = userAppService;
            _studentOfClassRoomApplicationService = studentOfClassRoomApplicationService;
            _classRoomAppService = classRoomAppService;
        }
        // GET: Students
        public ActionResult Index()
        {
            var students = _userAppService.GetStudents();
            return View(students);
        }
        public async System.Threading.Tasks.Task<ActionResult> GetStudentByClassRoom(GetStudentsOfClassRoomInput input)
        {
            var studentsOfClassRoom = await _studentOfClassRoomApplicationService.GetAsync(new Domain.StudentsOfClassRoom.Dto.GetStudentsOfClassRoomInput { ClassRoomId = input.ClassRoomId });
            var students = _userAppService.GetStudents();
            var classRooms = await _classRoomAppService.GetListAsync();
            ViewBag.ClassRoomId = classRooms.Where(x=>x.Id==input.ClassRoomId).Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name + " " + x.Branch
                                  });

            ViewBag.UserId = students.Select(x =>
                                  new SelectListItem()
                                  {
                                      Value = x.Id.ToString(),
                                      Text = x.Name + " " + x.Surname
                                  }); 

            return View("Index", studentsOfClassRoom);
        }
    }
}