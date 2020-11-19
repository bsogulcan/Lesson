using Abp.Domain.Entities;
using Lesson.Classes;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.Exam.Dto
{
    public class ExaminationsFullOutPut:Entity<int>
    {
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public UserPartOutput User { get; set; }
        public List<ExaminationQuestion> Questions { get; set; }

    }
}
