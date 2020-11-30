using Abp.Domain.Entities;
using Lesson.Domain.VideoContent.Dto;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContentLog.Dto
{
    public class VideoContentLogFullOutPut:Entity<int>
    {
        public UserPartOutput User { get; set; }
        public string Log { get; set; }
        public VideoContentFullOutPut VideoContent { get; set; }
        public bool IsCompleted { get; set; }

    }
}
