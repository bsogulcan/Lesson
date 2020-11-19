using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.StudentOfClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.RollCalls
{
    public class RollCallViewModel
    {
        public int RollCallId { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonId { get; set; }
        public int Session { get; set; }
        public List<ClassRoomFullOutPut> ClassRooms { get; set; }
        public List<Lesson.Domain.Lessons.Dto.LessonFullOutPut> Lessons { get; set; }
        public List<int> SessionList { get; set; } 
        public List<RollCallStudentViewModel> Students { get; set; }
    }
}