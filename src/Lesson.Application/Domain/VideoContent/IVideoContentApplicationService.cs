using Abp.Application.Services;
using Lesson.Domain.VideoContent.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContent
{
    public interface IVideoContentApplicationService:IApplicationService
    {
        Task<VideoContentFullOutPut> GetAsync(GetVideoContentInput input);
        Task<List<VideoContentFullOutPut>> GetListAsync();
        Task<VideoContentFullOutPut> CreateAsync(CreateVideoContentInput input);
        VideoContentFullOutPut GetVideoContentByHomeworkId(GetVideoContentInput input);

    }
}
