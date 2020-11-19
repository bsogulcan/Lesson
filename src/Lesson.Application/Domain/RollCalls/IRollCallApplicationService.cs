using Abp.Application.Services;
using Lesson.Domain.RollCalls.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCalls
{
    public interface IRollCallApplicationService:IApplicationService
    {
        Task<List<RollCallFullOutPut>> GetListAsync();
        Task<RollCallFullOutPut> GetAsync(GetRollCallInput input);
        Task<RollCallFullOutPut> CreateAsync(CreateRollCallInput input);
        Task DeleteAsync(DeleteRollCallInput input);
        Task<RollCallFullOutPut> UpdateAsync(UpdateRollCallInput input);

    }
}
