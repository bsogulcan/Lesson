﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Lessons.Dto
{
    public class UpdateLessonInput:Entity<int>
    {
        public string Name { get; set; }
    }
}
