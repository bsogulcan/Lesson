using Abp.Domain.Entities;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCalls.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCallDetails.Dto
{
    public class GetRollCallDetailInput:Entity<int>
    {
        public RollCallFullOutPut RollCall { get; set; }
    }
}
