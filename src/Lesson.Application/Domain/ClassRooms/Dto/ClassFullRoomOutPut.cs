using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Classes.Dto
{
    public class ClassRoomFullOutPut : EntityDto<int>
    {
        public string Name { get; set; }

        public string Branch { get; set; }

        public string Description { get; set; }

        public string FullClassName { get => Name + " " + Branch; }
    }
}
