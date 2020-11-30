using Abp.Domain.Entities;
using Lesson.Domain.VideoContentLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContent.Dto
{
    public class VideoContentFullOutPut:Entity<int>
    {
        public string Summary { get; set; }
        public byte[] Content { get; set; }
        public int VideoSize { get; set; }
        public string VideoName { get; set; }
        public string FileBase64 { get; set; }
        public List<VideoContentLogFullOutPut> VideoContentLogs { get; set; }


    }
}
