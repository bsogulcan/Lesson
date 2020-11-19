using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Lesson.Classes;
using Lesson.Domain.ClassRooms.Dto;
using Lesson.Domain.Lessons.Dto;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom.Dto
{
    public class LessonOfClassRoomFullOutPut: EntityDto<int>
    {
        public UserPartOutput User { get; set; }
        public LessonFullOutPut Lesson { get; set; }
        public ClassRoomPartOutPut ClassRoom { get; set; }
    }
}
