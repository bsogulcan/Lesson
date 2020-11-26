using Abp.Application.Services;
using Lesson.Domain.News.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.News
{
    public interface INewsApplicationService:IApplicationService
    {
        Task<NewsFullOutPut> CreateAsync(CreateNewsInput input);
        Task<NewsFullOutPut> GetAsync(GetNewsInput input);
        List<NewsFullOutPut> Search(GetNewsInput input);
        Task<List<NewsFullOutPut>> GetListAsync();
        Task<NewsFullOutPut> UpdateAsync(UpdateNewsInput input);
        
    }
}
