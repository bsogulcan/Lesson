using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.StudentOfClassRoom;
using Lesson.Domain.StudentsOfClassRoom;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lesson.Web.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly IClassRoomAppService _classRoomAppService;
        private readonly IStudentOfClassRoomApplicationService _studentOfClassRoomApplicationService;
        public ClassRoomsController(IClassRoomAppService classRoomAppService, IStudentOfClassRoomApplicationService studentOfClassRoomApplicationService)
        {
            _classRoomAppService = classRoomAppService;
            _studentOfClassRoomApplicationService = studentOfClassRoomApplicationService;
        }

        // GET: ClassRooms
        public async Task<ActionResult> Index()
        {
            var classRooms = await _classRoomAppService.GetListAsync();
            return View(classRooms);
        }

        public async Task<ActionResult> EditModal(int id)
        {
            var classRoom = await _classRoomAppService.GetAsync(new Domain.Classes.Dto.GetClassRoomInput { Id = id });
            var editModal = new EditClassRoomInput
            {
                Id = classRoom.Id,
                Name = classRoom.Name,
                Description = classRoom.Description,
                Branch = classRoom.Branch
            };
            return View("_EditModal", editModal);
        }

        
    }
}