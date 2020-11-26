using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.SubmittedHomeworks.Dto
{
    public class CreateSubmittedHomeworkInput
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public int HomeworkId { get; set; }
        public long UserId { get; set; }
        public string FileBase64 { get; set; }
        public byte[] File { get; set; } 
    }
}
