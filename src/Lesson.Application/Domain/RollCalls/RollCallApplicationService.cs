using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Classes;
using Lesson.Domain.RollCalls.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.RollCalls
{
    public class RollCallApplicationService : ApplicationService, IRollCallApplicationService
    {
        private readonly IRepository<RollCall> _rollCallRepository;
        private readonly IRepository<Lesson.Domain.Lessons.Lesson> _lessonRepository;
        private readonly IRepository<ClassRoom> _classRoom;


        public RollCallApplicationService(IRepository<RollCall> rollCallRepository, 
            IRepository<Lesson.Domain.Lessons.Lesson> lessonRepository,
            IRepository<ClassRoom> classRoom)
        {
            _rollCallRepository = rollCallRepository;
            _lessonRepository = lessonRepository;
            _classRoom = classRoom;
        }

        public async Task<RollCallFullOutPut> CreateAsync(CreateRollCallInput input)
        {
            var rollCall = new RollCall
            {
                Date = input.Date,
                Session = input.Session,
                Lesson=_lessonRepository.Get(input.LessonId),
                ClassRoom=_classRoom.Get(input.ClassRoomId),
                User = input.User
            };

            rollCall.Id=await _rollCallRepository.InsertAndGetIdAsync(rollCall);
            return ObjectMapper.Map<RollCallFullOutPut>(rollCall);

        }

        public async Task DeleteAsync(DeleteRollCallInput input)
        {
            await _rollCallRepository.DeleteAsync(_rollCallRepository.Get(input.Id));
        }

        public async Task<RollCallFullOutPut> GetAsync(GetRollCallInput input)
        {  
            var rollCall = await _rollCallRepository.GetAsync(input.Id);
            return ObjectMapper.Map<RollCallFullOutPut>(rollCall);
        }

        public async Task<List<RollCallFullOutPut>> GetListAsync()
        {
            var rollCalls = await _rollCallRepository.GetAllListAsync();
            return ObjectMapper.Map<List<RollCallFullOutPut>>(rollCalls);
        }

        public async Task<RollCallFullOutPut> UpdateAsync(UpdateRollCallInput input)
        {
            var rollCall = await _rollCallRepository.GetAsync(input.Id);
            rollCall.Date = input.Date;
            rollCall.Session = input.Session; 
            rollCall.User = input.User;

            return ObjectMapper.Map<RollCallFullOutPut>(rollCall); 
        }
    }
}
