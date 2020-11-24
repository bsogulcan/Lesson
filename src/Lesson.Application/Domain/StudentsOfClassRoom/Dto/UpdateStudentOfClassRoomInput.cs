using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsOfClassRoom.Dto
{
    public class UpdateStudentOfClassRoomInput:Entity<int>
    {
        public long UserId { get; set; }
        public int ClassRoomId { get; set; }

    }
}
