using Abp;
using Abp.Application.Services;
using Lesson.Domain.Homeworks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Homeworks
{
    public interface IHomeworkApplicationService:IApplicationService
    {
        Task<HomeworkFullOutPut> CreateAsync(CreateHomeworkInput input);
        Task DeleteAsync(DeleteHomeworkInput input);
        Task<List<HomeworkFullOutPut>> GetListAsync();
        List<HomeworkFullOutPut> GetListByStudents(GetHomeworkInput input);
        Task<HomeworkFullOutPut> GetAsync(GetHomeworkInput input);
        Task<HomeworkFullOutPut> UpdateAsync(UpdateHomeworkInput input);
        Task Subscribe_Homeworks(long userId);
        Task Publish_Homeworks(UserIdentifier targetUserId);
    }
}
