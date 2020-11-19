using Abp.Application.Services;
using Lesson.Domain.RollCallDetails.Dto;
using Lesson.Domain.RollCalls.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCallDetails
{
    public interface IRollCallDetailApplicationService : IApplicationService
    {
        Task<RollCallDetailFullOutPut> GetAsync(GetRollCallDetailInput input);
        Task<List<RollCallDetailFullOutPut>> GetByRollCallIdAsync(GetRollCallDetailInput input);
        Task<List<RollCallDetailFullOutPut>> GetListAsync();
        Task<RollCallDetailFullOutPut> CreateAsync(CreateRollCallDetailInput input);
        Task<RollCallDetailFullOutPut> UpdateAsync(UpdateRollCallDetailInput input);
        Task DeleteAsync(DeleteRollCallDetailInput input);
        Task<RollCallDetailFullOutPut> UpdateRollCallTypeAsync(UpdateRollCallDetailInput input);
    }
}
