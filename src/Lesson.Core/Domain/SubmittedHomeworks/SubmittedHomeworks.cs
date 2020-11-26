using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;

namespace Lesson.Domain.SubmittedHomeworks
{
    public class SubmittedHomeworks:FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public int? HomeworkId { get; set; }
        [ForeignKey("HomeworkId")]
        public virtual Homeworks.Homework Homework { get; set; }
        public virtual User User { get; set; }
        public byte[] File{ get; set; }
    }
}