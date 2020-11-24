using Abp.Application.Services;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsOfClassRoom
{
    public interface IStudentOfClassRoomApplicationService:IApplicationService
    {
        Task<StudentsOfClassRoomFullOutPut> CreateAsync(CreateStudentOfClassRoomInput input);
        Task DeleteAsync(DeleteStudentOfClassRoomInput input);
        Task<List<StudentsOfClassRoomFullOutPut>> GetListAsync();
        List<StudentsOfClassRoomFullOutPut> Get(GetStudentsOfClassRoomInput input);
        Task<List<StudentsOfClassRoomFullOutPut>> GetAsync(GetStudentsOfClassRoomInput input);
        List<StudentsOfClassRoomFullOutPut> GetStudentsLessons(GetLessonOfClassRoomInput input);

    }
}
