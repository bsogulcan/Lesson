using Lesson.Authorization.Users;
using Lesson.Domain;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson.Web.Models.RollCalls
{
    public class RollCallStudentViewModel
    {
        public int RollCallDetailId { get; set; }
        public int RollCallId { get; set; }
        public RollCallType RollCallType { get; set; }
        public User User { get; set; }
    }
}