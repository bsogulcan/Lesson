using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Classes;

namespace Lesson.Domain.Lessons
{
    public class Lesson : FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
    }
}
