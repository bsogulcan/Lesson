using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Lessons.Dto
{
    public class LessonApplicationService : ApplicationService, ILessonApplicationService
    {
        private readonly IRepository<Lesson> _lessonRepository;
        public LessonApplicationService(IRepository<Lesson> lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonFullOutPut> CreateAsync(CreateLessonInput input)
        {
            var lesson = new Lesson
            {
                Name = input.Name
            };
            await _lessonRepository.InsertAsync(lesson);
            return ObjectMapper.Map<LessonFullOutPut>(lesson);
        }

        public async Task DeleteAsync(DeleteLessonInput input)
        {
            await _lessonRepository.DeleteAsync(input.Id);
        }
         
        public async Task<LessonFullOutPut> GetAsync(GetLessonInput input)
        {
            var lesson = await _lessonRepository.GetAsync(input.Id);
            return ObjectMapper.Map<LessonFullOutPut>(lesson);
        }

        public async Task<List<LessonFullOutPut>> GetListAsync()
        {
            var lessons = await _lessonRepository.GetAllListAsync();
            return ObjectMapper.Map<List<LessonFullOutPut>>(lessons);
        }

        public async Task<LessonFullOutPut> UpdateAsync(UpdateLessonInput input)
        {
            var lesson = await _lessonRepository.GetAsync(input.Id);
            lesson.Name = input.Name;
            return ObjectMapper.Map<LessonFullOutPut>(lesson);
        }
    }
}
