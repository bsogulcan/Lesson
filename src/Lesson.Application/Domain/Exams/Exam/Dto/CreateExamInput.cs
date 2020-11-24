using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.Exam.Dto
{
    public class CreateExamInput
    {
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public int ClassRoomId { get; set; }
        public int LessonId { get; set; }
        public long UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ExaminationQuestion> Questions { get; set; }
    }
}
