using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public long? UserId { get; set; }
        public int? ExaminationId { get; set; }
        public int? ExaminationQuestionId { get; set; }
        public int? ExaminationQuestionAnswerId { get; set; } 

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [ForeignKey("ExaminationId")]
        public virtual Examination Examination { get; set; }
        [ForeignKey("ExaminationQuestionId")]
        public virtual ExaminationQuestion ExaminationQuestion { get; set; }
        [ForeignKey("ExaminationQuestionAnswerId")]
        public virtual ExaminationQuestionAnswer ExaminationQuestionAnswer { get; set; }

    }
}
