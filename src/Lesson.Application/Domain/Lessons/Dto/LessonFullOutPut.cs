using Abp.Domain.Entities;
using Lesson.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Lessons.Dto
{
    public class LessonFullOutPut:Entity<int>
    {
        public string Name { get; set; }
        public ClassRoom ClassRoom { get; set; }

    }
}
