using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.VideoContent.Dto;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Homeworks.Dto
{
    public class CreateHomeworkInput
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public Lesson.Domain.Lessons.Dto.LessonFullOutPut Lesson { get; set; }
        public ClassRoomFullOutPut ClassRoom { get; set; }
        public UserPartOutput User { get; set; }
        public DateTime Deadline { get; set; }

    }
}
