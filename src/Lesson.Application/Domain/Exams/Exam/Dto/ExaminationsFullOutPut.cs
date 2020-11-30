using Abp.Domain.Entities;
using Lesson.Classes;
using Lesson.Domain.StudentsAnswersOfExam.Dto;
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
        public virtual Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public virtual UserPartOutput User { get; set; }
        public virtual List<ExaminationQuestion> Questions { get; set; }
        public int CorrectAnswerCount { get; set; }
        public int WrongAnswerCount { get; set; }
        public int AnswerCount { get; set; }
        public bool Approved { get; set; }
        public virtual List<StudentsAnswerOfExamFullOutPut> StudentsAnswers { get; set; }

    }
}
