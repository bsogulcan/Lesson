﻿using Abp.Domain.Entities;
using Lesson.Authorization.Users;
using Lesson.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Homeworks.Dto
{
    public class HomeworkFullOutPut : Entity<int>
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public User User { get; set; }
        public DateTime Deadline { get; set; }

    }
}