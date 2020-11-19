using Abp.Domain.Entities;
using Lesson.Classes.Dto;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCalls.Dto
{
    public class RollCallFullOutPut:Entity<int>
    {
        public DateTime Date { get; set; }
        public int Session { get; set; }
        public UserPartOutput User { get; set; } 
        public ClassRoomFullOutPut ClassRoom { get; set; }
        public Lesson.Domain.Lessons.Dto.LessonFullOutPut Lesson { get; set; }

    }
}
