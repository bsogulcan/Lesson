using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
namespace Lesson.Domain.Exams
{
    public class ExaminationQuestionAnswer:FullAuditedAggregateRoot<int>
    {
        public virtual ExaminationQuestion ExaminationQuestion { get; set; }
        public string Answer { get; set; }
        public bool Status { get; set; }
    }
}