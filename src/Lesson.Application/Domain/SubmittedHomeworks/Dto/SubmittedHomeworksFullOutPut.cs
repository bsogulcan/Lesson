using Abp.Domain.Entities;
using Lesson.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.SubmittedHomeworks.Dto
{
    public class SubmittedHomeworksFullOutPut:Entity<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public Homeworks.Homework Homework { get; set; }
        public User User { get; set; }
        public byte[] File { get; set; }

    }
}
