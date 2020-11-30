using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
namespace Lesson.Domain.VideoContent
{
    public class VideoContent:FullAuditedAggregateRoot<int>
    {
        public string Summary { get; set; }
        public byte[] Content { get; set; }
        public int VideoSize { get; set; }
        public string VideoName { get; set; }
        public int HomeworkId { get; set; }
        public virtual List<VideoContentLog> VideoContentLogs { get; set; }
    }
}
