using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Domain.RollCalls;

namespace Lesson.Domain.RollCallsDetail
{
    public class RollCallDetail : FullAuditedAggregateRoot<int>
    {
        public virtual RollCall RollCall { get; set; }
        public virtual User User { get; set; }
        public virtual RollCallType RollCallType { get; set; }
    }
}
