using Abp.Application.Services;
using Lesson.Domain.Lessons.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Lessons
{
    public interface ILessonApplicationService:IApplicationService
    {
        Task<LessonFullOutPut> CreateAsync(CreateLessonInput input);
        Task DeleteAsync(DeleteLessonInput input);
        Task<List<LessonFullOutPut>> GetListAsync(); 
        Task<LessonFullOutPut> GetAsync(GetLessonInput input);
        Task<LessonFullOutPut> UpdateAsync(UpdateLessonInput input); 
    }
}
