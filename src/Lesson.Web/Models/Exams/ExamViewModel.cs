using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Domain.Exams;
using Lesson.Domain.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.Exams
{
    [Serializable]
    public class ExamViewModel
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
        public int TimeLimit { get; set; } = 45;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }
        public int ClassRoomId { get; set; }
        public List<ClassRoomFullOutPut> ClassRooms { get; set; }
        public int LessonId { get; set; }
        public List<LessonFullOutPut> Lessons { get; set; }
        public List<ExaminationQuestion> Questions { get; set; }

    }
}