using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Domain.RollCallDetails.Dto;
using Lesson.Domain.RollCalls;
using Lesson.Domain.RollCallsDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCallDetails
{
    public class RollCallDetailApplicationService : ApplicationService, IRollCallDetailApplicationService
    {

        private readonly IRepository<RollCallDetail> _roleCallDetailRepository;
        private readonly IRepository<RollCall> _roleCallRepository;

        public RollCallDetailApplicationService(IRepository<RollCallDetail> roleCallDetailRepository,
            IRepository<RollCall> roleCallRepository)
        {
            _roleCallDetailRepository = roleCallDetailRepository;
            _roleCallRepository = roleCallRepository;
        }

        public async Task<RollCallDetailFullOutPut> CreateAsync(CreateRollCallDetailInput input)
        {
            var roleCallDetail = new RollCallDetail
            {
                User = input.User,
                RollCall = await _roleCallRepository.GetAsync(input.RollCall.Id),
                RollCallType = input.RollCallType
            };

            roleCallDetail.Id= await _roleCallDetailRepository.InsertAndGetIdAsync(roleCallDetail);
            return ObjectMapper.Map<RollCallDetailFullOutPut>(roleCallDetail);
        }

        public async Task<RollCallDetailFullOutPut> GetAsync(GetRollCallDetailInput input)
        {
            var rollCallDetail = await _roleCallDetailRepository.GetAsync(input.Id);
            return ObjectMapper.Map<RollCallDetailFullOutPut>(rollCallDetail);
        }

        public async Task<List<RollCallDetailFullOutPut>> GetByRollCallIdAsync(GetRollCallDetailInput input)
        {
            var rollCallDetails = await _roleCallDetailRepository.GetAllListAsync();
            rollCallDetails=rollCallDetails.Where(x => x.RollCall != null && x.RollCall.Id == input.RollCall.Id).ToList(); 
            return ObjectMapper.Map<List<RollCallDetailFullOutPut>>(rollCallDetails);
        }

        public async Task<List<RollCallDetailFullOutPut>> GetListAsync()
        {
            var rollCallDetails = await _roleCallDetailRepository.GetAllListAsync();
            return ObjectMapper.Map<List<RollCallDetailFullOutPut>>(rollCallDetails);
        }

        public async Task<RollCallDetailFullOutPut> UpdateAsync(UpdateRollCallDetailInput input)
        {
            var rollCallDetail = await _roleCallDetailRepository.GetAsync(input.Id);
            rollCallDetail.RollCall = input.RollCall;
            rollCallDetail.User = input.User;
            rollCallDetail.RollCallType = input.RollCallType;

            return ObjectMapper.Map<RollCallDetailFullOutPut>(rollCallDetail);
        }

        public async Task DeleteAsync(DeleteRollCallDetailInput input)
        {
            await _roleCallDetailRepository.DeleteAsync(input.Id);
        }

        public async Task<RollCallDetailFullOutPut> UpdateRollCallTypeAsync(UpdateRollCallDetailInput input)
        {
            var rollCallDetail = await _roleCallDetailRepository.GetAsync(input.Id); 
            rollCallDetail.RollCallType = input.RollCallType;
            _roleCallDetailRepository.UpdateAsync(rollCallDetail);
            return ObjectMapper.Map<RollCallDetailFullOutPut>(rollCallDetail);
        }
    }
}
