using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom.Dto
{
    public class CreateLessonOfClassRoomInput
    {
        public int LessonId { get; set; }
        public int ClassRoomId { get; set; }
        public int UserId { get; set; }
    }
}
