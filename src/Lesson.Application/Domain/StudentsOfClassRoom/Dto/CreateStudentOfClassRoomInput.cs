using Lesson.Classes;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsOfClassRoom.Dto
{
    public class CreateStudentOfClassRoomInput
    {
        public int UserId { get; set; }
        public int ClassRoomId { get; set; }
    }
}
