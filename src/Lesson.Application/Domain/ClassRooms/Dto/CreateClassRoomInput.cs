﻿using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Classes.Dto
{
    public class CreateClassRoomInput
    {
        [Required]
        public string Name { get; set; }

        [Required] 
        public string Branch { get; set; }

        [MaxLength(120)]
        public string Description { get; set; }

    }
}
