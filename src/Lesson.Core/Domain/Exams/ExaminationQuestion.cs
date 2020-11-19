using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;

namespace Lesson.Domain.Exams
{
    public class ExaminationQuestion:FullAuditedAggregateRoot<int>
    {
        public virtual Examination Examination { get; set; }
        public string Question { get; set; }
        public virtual List<ExaminationQuestionAnswer> Answers { get; set; }
    }
}
