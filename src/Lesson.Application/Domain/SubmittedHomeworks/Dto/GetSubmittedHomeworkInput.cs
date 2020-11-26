using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.SubmittedHomeworks.Dto
{
    public class GetSubmittedHomeworkInput:Entity<int>
    {
        public int HomeworkId { get; set; }
    }
}
