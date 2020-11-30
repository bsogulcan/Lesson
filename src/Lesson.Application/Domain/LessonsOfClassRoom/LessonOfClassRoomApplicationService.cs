using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.Lessons;
using Lesson.Domain.Lessons.Dto;
using Lesson.Domain.LessonsOfClassRoom.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.LessonsOfClassRoom
{
    public class LessonOfClassRoomApplicationService : ApplicationService, ILessonOfClassRoomApplicationService
    {

        private readonly IRepository<LessonOfClassRoom> _lessonOfClassRoom;
        private readonly UserManager _userManager;
        private readonly IRepository<ClassRoom> _classRoomRepository;
        private readonly IRepository<Lesson.Domain.Lessons.Lesson> _lessonRepository;
        public LessonOfClassRoomApplicationService(IRepository<LessonOfClassRoom> lessonOfClassRoom, UserManager userManager, IRepository<ClassRoom> classRoomAppService, IRepository<Lesson.Domain.Lessons.Lesson> lessonApplicationService)
        {
            _lessonOfClassRoom = lessonOfClassRoom;
            _userManager = userManager;
            _classRoomRepository = classRoomAppService;
            _lessonRepository = lessonApplicationService;
        }

        public async Task<LessonOfClassRoomFullOutPut> CreateAsync(CreateLessonOfClassRoomInput input)
        {  
            var lessonOfClassRoom = new LessonOfClassRoom
            {
                ClassRoom = await _classRoomRepository.GetAsync(input.ClassRoomId),
                User = _userManager.GetUserById(input.UserId),
                Lesson = await _lessonRepository.GetAsync(input.LessonId) 
            }; 

            await _lessonOfClassRoom.InsertAsync(lessonOfClassRoom);
            return ObjectMapper.Map<LessonOfClassRoomFullOutPut>(lessonOfClassRoom); 
        }

        public async Task DeleteAsync(DeleteLessonOfClassRoomInput input)
        {
            await _lessonOfClassRoom.DeleteAsync(input.Id);
        }

        public async Task<LessonOfClassRoomFullOutPut> GetAsync(GetLessonOfClassRoomInput input)
        {
            var lessonOfClassRoom = await _lessonOfClassRoom.GetAsync(input.Id);
            return ObjectMapper.Map<LessonOfClassRoomFullOutPut>(lessonOfClassRoom);
        }

        public async Task<List<LessonOfClassRoomFullOutPut>> GetListAsync()
        {
            var lessonsOfClassRoom = await _lessonOfClassRoom.GetAllListAsync();
            return ObjectMapper.Map<List<LessonOfClassRoomFullOutPut>>(lessonsOfClassRoom);
        }

        public async Task<List<LessonFullOutPut>> GetListLessonsOfClassRoom(GetLessonOfClassRoomInput input)
        {
            List<LessonFullOutPut> lessonOfClassFullOutPut = new List<LessonFullOutPut>();

            var lessonsOfClassRooms = _lessonOfClassRoom.GetAllIncluding().Where(x => x.ClassRoomId == input.ClassRoomId).ToList();

            foreach (var lessonsOfClassRoom in lessonsOfClassRooms)
            {
                var lessonDto = ObjectMapper.Map<LessonFullOutPut>(lessonsOfClassRoom.Lesson);
                lessonOfClassFullOutPut.Add(lessonDto);
            }
            return lessonOfClassFullOutPut;
        }

        public List<LessonOfClassRoomFullOutPut> GetListLessonsOfClassRoomBaseOutPut(GetLessonOfClassRoomInput input)
        {
            var lessonsOfClassRooms = _lessonOfClassRoom.GetAllIncluding().Where(x => x.ClassRoomId == input.ClassRoomId).ToList();
            return ObjectMapper.Map<List<LessonOfClassRoomFullOutPut>>(lessonsOfClassRooms); 

        }

        public List<LessonOfClassRoomFullOutPut> GetListLessonsOfClassRoomById(int classRoomId)
        {
            var lessonsOfClassRoom = _lessonOfClassRoom.GetAllIncluding().Where(x => x.ClassRoomId == classRoomId).ToList();
            return ObjectMapper.Map<List<LessonOfClassRoomFullOutPut>>(lessonsOfClassRoom);
        }

        public List<LessonOfClassRoomFullOutPut> GetStudentLessonsOfClassRoom(GetLessonOfClassRoomInput input)
        {
            //var lessonOfClassRoom = _lessonOfClassRoom.GetAllIncluding().Where(x => x.ClassRoom.Id ).ToList();
            //return ObjectMapper.Map<List<LessonOfClassRoomFullOutPut>>(lessonOfClassRoom.ToList());
            return null;
        }

        public List<LessonOfClassRoomFullOutPut> GetTeacherLessonsOfClassRoom(GetLessonOfClassRoomInput input)
        { 
            var lessonOfClassRoom = _lessonOfClassRoom.GetAllIncluding().Where(x => x.UserId == input.UserId).ToList();
            return ObjectMapper.Map<List<LessonOfClassRoomFullOutPut>>(lessonOfClassRoom.ToList());
        }

        public async Task<LessonOfClassRoomFullOutPut> UpdateAsync(UpdateLessonsOfClassRoomInput input)
        {
            var lessonOfClassRoom = await _lessonOfClassRoom.GetAsync(input.Id);
            lessonOfClassRoom.User = _userManager.GetUserById(input.UserId);
            lessonOfClassRoom.Lesson = _lessonRepository.Get(input.LessonId);
            lessonOfClassRoom.ClassRoom = _classRoomRepository.Get(input.ClassRoomId);

            await _lessonOfClassRoom.UpdateAsync(lessonOfClassRoom);

            return ObjectMapper.Map<LessonOfClassRoomFullOutPut>(lessonOfClassRoom);
        }
    }
}