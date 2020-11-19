using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsAnswersOfExam.Dto
{
    public class CreateStudentsAnswerOfExamInput
    {
        public int UserId { get; set; }
        public int ExaminationId { get; set; }
        public int ExaminationQuestionId { get; set; }
        public int ExaminationQuestionAnswerId { get; set; }
    }
}
