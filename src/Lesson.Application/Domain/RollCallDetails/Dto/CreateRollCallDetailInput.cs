using Lesson.Authorization.Users;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCalls.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCallDetails.Dto
{
    public class CreateRollCallDetailInput
    {
        public RollCallFullOutPut RollCall { get; set; }
        public User User{ get; set; }
        public RollCallType RollCallType { get; set; }
    }
}
