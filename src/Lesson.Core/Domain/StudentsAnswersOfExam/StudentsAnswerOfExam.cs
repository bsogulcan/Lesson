using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Domain.Exams;

namespace Lesson.Domain.StudentsAnswerOfExam
{
    public class StudentsAnswerOfExam:AuditedAggregateRoot<int>
    {
        public virtual User User { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual ExaminationQuestion ExaminationQuestion { get; set; }
        public virtual ExaminationQuestionAnswer ExaminationQuestionAnswer { get; set; }

    }
}
