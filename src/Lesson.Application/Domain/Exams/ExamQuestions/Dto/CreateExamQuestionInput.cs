using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.ExamQuestions.Dto
{
    public class CreateExamQuestionInput
    {
        public string Question { get; set; }
        public List<ExaminationQuestionAnswer> Answers { get; set; }

    }
}
