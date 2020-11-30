using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContentLog.Dto
{
    public class GetVideoContenLogInput:Entity<int>
    {
        public int VideoContentId { get; set; }

    }
}
