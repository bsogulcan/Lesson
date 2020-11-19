using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.Domain.Entities.Auditing;

namespace Lesson.Categories.Dto
{
    public class CategoryInput:Abp.Application.Services.Dto.EntityDto<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
