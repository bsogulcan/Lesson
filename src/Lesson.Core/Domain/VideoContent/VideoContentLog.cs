using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;

namespace Lesson.Domain.VideoContent
{
    public class VideoContentLog:FullAuditedAggregateRoot<int>
    {
        public virtual User User { get; set; }
        public string Log { get; set; }
        public int VideoContentId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
