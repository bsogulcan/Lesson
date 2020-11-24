using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
namespace Lesson.Domain.News
{
    public class News:FullAuditedAggregateRoot<int>
    {
        public string Summary { get; set; }
        public string Content { get; set; }
    }
}
