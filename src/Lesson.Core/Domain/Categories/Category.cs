using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Auditing;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;

namespace Lesson.Categories
{
    public class Category:FullAuditedAggregateRoot
    {
        [Required]
        [Display(Name="Category Name")]
        [StringLength(64,ErrorMessage ="Maximum Lenght is 64")]
        public string Name { get; set; }
    }
}
