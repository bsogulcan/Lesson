using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Lesson.Authorization.Users;
using Lesson.Manager;
using Lesson.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.News.Dto
{
    public class NewsFullOutPut:Entity<int>
    {
        public string Summary { get; set; }
        public string Content { get; set; }
        public long CreatorUserId { get; set; }
        public User User{ get; set; }
        public DateTime CreateionTime { get; set; }
         
    }
}
