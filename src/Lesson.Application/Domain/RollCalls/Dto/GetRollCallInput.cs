using Abp.Domain.Entities;
using Lesson.Domain.ClassRooms.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Lesson.Domain.RollCalls.Dto
{
    public class GetRollCallInput:Entity<int>
    {
        public ClassRoomPartOutPut ClassRoom { get; set; }
        public Lesson.Domain.Lessons.Lesson Lesson { get; set; } 
    }
}
