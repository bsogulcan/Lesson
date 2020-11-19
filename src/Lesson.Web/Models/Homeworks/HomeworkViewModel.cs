using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Classes.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.Homeworks
{
    public class HomeworkViewModel
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public int LessonId { get; set; }
        public List<Lesson.Domain.Lessons.Dto.LessonFullOutPut> Lessons { get; set; }
        public int ClassRoomId { get; set; }
        public List<ClassRoomFullOutPut> ClassRooms { get; set; }
        //public User User { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Deadline { get; set; }

    }
}