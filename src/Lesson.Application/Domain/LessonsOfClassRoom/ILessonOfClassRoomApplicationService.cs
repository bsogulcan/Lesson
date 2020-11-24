using Abp.Application.Services;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom
{
    public interface ILessonOfClassRoomApplicationService:IApplicationService
    {
        Task<LessonOfClassRoomFullOutPut> CreateAsync(CreateLessonOfClassRoomInput input);
        Task DeleteAsync(DeleteLessonOfClassRoomInput input);
        Task<List<LessonOfClassRoomFullOutPut>> GetListAsync();
        Task<LessonOfClassRoomFullOutPut> GetAsync(GetLessonOfClassRoomInput input);
        Task<LessonOfClassRoomFullOutPut> UpdateAsync(UpdateLessonsOfClassRoomInput input);
        Task<List<LessonFullOutPut>> GetListLessonsOfClassRoom(GetLessonOfClassRoomInput input);
        List<LessonOfClassRoomFullOutPut> GetListLessonsOfClassRoomBaseOutPut(GetLessonOfClassRoomInput input);
        List<LessonOfClassRoomFullOutPut> GetListLessonsOfClassRoomById(int classRoomId);
        List<LessonOfClassRoomFullOutPut> GetTeacherLessonsOfClassRoom(GetLessonOfClassRoomInput input);
        List<LessonOfClassRoomFullOutPut> GetStudentLessonsOfClassRoom(GetLessonOfClassRoomInput input);
        
    }
}
