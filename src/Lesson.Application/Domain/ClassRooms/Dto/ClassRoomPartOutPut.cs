using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.ClassRooms.Dto
{
    public class ClassRoomPartOutPut:Entity<int>
    {
        public string Name { get; set; }
        public string Branch { get; set; }
        public string Description { get; set; }

    }
}
