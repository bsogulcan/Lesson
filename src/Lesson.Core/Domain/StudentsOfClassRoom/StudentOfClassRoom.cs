﻿using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Lesson.Authorization.Users;
using Lesson.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentOfClassRoom
{
    public class StudentOfClassRoom:FullAuditedAggregateRoot
    {

        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual ClassRoom ClassRoom { get; set; } 
    }
}
