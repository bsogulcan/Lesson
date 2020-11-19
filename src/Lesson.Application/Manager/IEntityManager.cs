using Abp.Dependency;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.Homeworks;
using Lesson.Domain.StudentOfClassRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Manager
{
    public interface IEntityManager : ITransientDependency
    {
        Task<Homework> GetHomeworkAsync(int homeworkId);
        Task<Lesson.Domain.Lessons.Lesson> GetLessonAsync(int lessonId);
        Task<ClassRoom> GetClassRoomAsync(int classRoomId); 
        List<StudentOfClassRoom> GetClassRoomsByStudents(int studentId); 
        Task<User> GetUserById(int userId); 

    }
}
