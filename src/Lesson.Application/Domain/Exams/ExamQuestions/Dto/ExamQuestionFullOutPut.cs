using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.ExamQuestions.Dto
{
    public class ExamQuestionFullOutPut:Entity<int>
    {
        public string Question { get; set; }
        public List<ExaminationQuestionAnswer> Answers { get; set; }
    }
}
