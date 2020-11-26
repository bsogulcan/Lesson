using Abp;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.Homeworks;
using Lesson.Domain.StudentOfClassRoom;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Manager
{
    public class EntityManager : AbpServiceBase, IEntityManager
    {
        private readonly IRepository<Homework> _homeworkRepository;
        private readonly IRepository<Lesson.Domain.Lessons.Lesson> _lessonRepository;
        private readonly IRepository<ClassRoom> _classRoomRepository;
        private readonly IRepository<StudentOfClassRoom> _studentsOfClassRooms;
        private readonly UserManager _userManager;
        public EntityManager(IRepository<Homework> homeworkRepository,
            IRepository<Lesson.Domain.Lessons.Lesson> lessonRepository,
            IRepository<ClassRoom> classRoomRepository,
            IRepository<StudentOfClassRoom> studentsOfClassRooms,
            UserManager userManager)
        {
            _homeworkRepository = homeworkRepository;
            _lessonRepository = lessonRepository;
            _classRoomRepository = classRoomRepository;
            _studentsOfClassRooms = studentsOfClassRooms;
            _userManager = userManager;
        }

        public Task<ClassRoom> GetClassRoomAsync(int classRoomId)
        {
            var classRoom = _classRoomRepository.FirstOrDefaultAsync(x => x.Id == classRoomId);
            if (classRoom == null)
            {
                throw new EntityNotFoundException(typeof(ClassRoom), classRoom);
            }
            return classRoom;
        }

        public List<StudentOfClassRoom> GetClassRoomsByStudents(int studentId)
        {
            var studentOfClassRooms = _studentsOfClassRooms.GetAllList().Where(x => x.User != null && x.User.Id==studentId).ToList();
            return studentOfClassRooms;
        }

        public async Task<Homework> GetHomeworkAsync(int homeworkId)
        {
            var homework =await _homeworkRepository.FirstOrDefaultAsync(x => x.Id == homeworkId);
            if (homework == null)
            {
                throw new EntityNotFoundException(typeof(Homework), homeworkId);
            }
            return homework;
        }

        public Task<Domain.Lessons.Lesson> GetLessonAsync(int lessonId)
        {
            var lesson = _lessonRepository.FirstOrDefaultAsync(x => x.Id == lessonId);
            if (lesson == null)
            {
                throw new EntityNotFoundException(typeof(Lesson.Domain.Lessons.Lesson), lesson);
            }
            return lesson;
        }

        public async Task<User> GetUserById(long userId)
        {
            return await _userManager.GetUserByIdAsync(userId);
        }

        public User GetUserByIdSync(long userId)
        {
            return _userManager.GetUserById(userId);
        }
    }
}
