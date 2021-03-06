﻿using Abp.Domain.Entities.Auditing;
using Lesson.Authorization.Users;
using Lesson.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom
{
    public class LessonOfClassRoom : FullAuditedAggregateRoot
    { 
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }  
        public virtual Lesson.Domain.Lessons.Lesson Lesson { get; set; }
        public int? ClassRoomId { get; set; }
        [ForeignKey("ClassRoomId")]
        public virtual ClassRoom ClassRoom { get; set; } 
    }
}
