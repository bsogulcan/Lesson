using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Classes;

namespace Lesson.Domain.Exams
{
    public class Examination: FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public int TimeLimit { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public virtual User User { get; set; }
        public virtual List<ExaminationQuestion> Questions { get; set; }
        public virtual List<StudentsAnswerOfExam.StudentsAnswerOfExam> StudentsAnswers { get; set; }
    }
}