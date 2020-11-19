using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCalls
{
    public class RollCall:FullAuditedAggregateRoot<int>
    {
        public DateTime Date { get; set; }
        public int Session { get; set; }
        public virtual User User { get; set; }
        public virtual Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
