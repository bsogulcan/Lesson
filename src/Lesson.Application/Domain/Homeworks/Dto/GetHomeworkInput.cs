using Abp.Domain.Entities;
using Lesson.Classes;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Homeworks.Dto
{
    public class GetHomeworkInput:Entity<int>
    {
        public Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public DateTime Deadline { get; set; }
        public UserPartOutput User{ get; set; } 
    }
}
