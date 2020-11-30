using Abp.Application.Services;
using Lesson.Domain.VideoContentLog.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContentLog
{
    public interface IVideoContentLogApplicationService:IApplicationService
    {
        Task<VideoContentLogFullOutPut> CreateAsync(CreateVideoContentLogInput input);
        Task<List<VideoContentLogFullOutPut>> GetAsync(GetVideoContenLogInput input);
    }
}
