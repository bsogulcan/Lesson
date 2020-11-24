using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.News.Dto
{
    public class UpdateNewsInput:Entity<int>
    {
        public string Summary { get; set; }
        public string Content { get; set; }

    }
}
