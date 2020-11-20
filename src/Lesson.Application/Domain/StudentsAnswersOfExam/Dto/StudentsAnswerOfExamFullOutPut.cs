using Abp.Domain.Entities;
using Lesson.Domain.Exams;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsAnswersOfExam.Dto
{
    public class StudentsAnswerOfExamFullOutPut:Entity<int>
    {
        public UserPartOutput User { get; set; }
        public Examination Examination { get; set; }
        public ExaminationQuestion ExaminationQuestion { get; set; }
        public ExaminationQuestionAnswer ExaminationQuestionAnswer { get; set; }
    }
}
