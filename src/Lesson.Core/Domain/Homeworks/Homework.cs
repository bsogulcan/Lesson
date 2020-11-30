using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Classes;

namespace Lesson.Domain.Homeworks
{
    public class Homework : FullAuditedAggregateRoot<int>
    {
        public string Summary { get; set; }
        public string Description { get; set; }
        public virtual Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual User User { get; set; }
        public DateTime Deadline { get; set; }
        public virtual List<SubmittedHomeworks.SubmittedHomeworks> SubmittedHomeworks { get; set; }
    }
}