using Abp.Application.Services;
using Lesson.Domain.SubmittedHomeworks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.SubmittedHomeworks
{
    public interface ISubmittedHomeworksApplicationService:IApplicationService
    {
        Task<List<SubmittedHomeworksFullOutPut>> GetListAsync();
        Task<SubmittedHomeworksFullOutPut> GetAsync(GetSubmittedHomeworkInput input);
        List<SubmittedHomeworksFullOutPut> GetByHomework(GetSubmittedHomeworkInput input);
        Task<SubmittedHomeworksFullOutPut> CreateAsync(CreateSubmittedHomeworkInput input);
    }
}
