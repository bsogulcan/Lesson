using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContentLog.Dto
{
    public class CreateVideoContentLogInput
    {
        public int UserId { get; set; }
        public string Log { get; set; }
        public int VideoContentId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
