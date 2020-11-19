using Abp.Domain.Entities;
using Lesson.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCalls.Dto
{
    public class UpdateRollCallInput:Entity<int>
    {
        public DateTime Date { get; set; }
        public int Session { get; set; }
        public User User { get; set; }
        public RollCallType Status { get; set; }
    }
}
