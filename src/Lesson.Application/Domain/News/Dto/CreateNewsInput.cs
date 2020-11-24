using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.News.Dto
{
    public class CreateNewsInput
    {
        public string Summary { get; set; }
        public string Content { get; set; }
    }
}
