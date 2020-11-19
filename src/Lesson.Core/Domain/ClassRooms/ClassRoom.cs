using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;

namespace Lesson.Classes
{
    public class ClassRoom : FullAuditedAggregateRoot<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Branch { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }
         
    }
}
