using Abp.Domain.Entities;
using Lesson.Classes;
using Lesson.Classes.Dto;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsOfClassRoom.Dto
{
    public class StudentsOfClassRoomFullOutPut:Entity<int>
    {
        public UserPartOutput User { get; set; }
        public ClassRoomFullOutPut ClassRoom { get; set; }
    }
}
