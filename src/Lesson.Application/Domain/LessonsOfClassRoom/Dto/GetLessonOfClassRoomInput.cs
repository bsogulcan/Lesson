using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom.Dto
{
    public class GetLessonOfClassRoomInput:Entity<int>
    {
        public int LessonId { get; set; }
        public int ClassRoomId { get; set; }
        public long UserId { get; set; }

    }
}
