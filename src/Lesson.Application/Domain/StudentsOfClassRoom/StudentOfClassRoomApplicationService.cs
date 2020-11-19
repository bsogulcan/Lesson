using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.StudentsOfClassRoom.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsOfClassRoom
{
    public class StudentOfClassRoomApplicationService : ApplicationService, IStudentOfClassRoomApplicationService
    {
        private readonly IRepository<StudentOfClassRoom.StudentOfClassRoom> _studentOfClassRoom;
        private readonly UserManager _userManager;
        private readonly IRepository<ClassRoom> _classRoomRepository;
        public StudentOfClassRoomApplicationService(IRepository<StudentOfClassRoom.StudentOfClassRoom> studentOfClassRoom, UserManager userManager, IRepository<ClassRoom> classRoomRepository)
        {
            _studentOfClassRoom = studentOfClassRoom;
            _userManager = userManager;
            _classRoomRepository = classRoomRepository;
        }

        public async Task<StudentsOfClassRoomFullOutPut> CreateAsync(CreateStudentOfClassRoomInput input)
        {
            var studentOfClassRoom = new StudentOfClassRoom.StudentOfClassRoom
            {
                User = _userManager.GetUserById(input.UserId),
                ClassRoom = _classRoomRepository.Get(input.ClassRoomId)
            };
            await _studentOfClassRoom.InsertAsync(studentOfClassRoom);

            return ObjectMapper.Map<StudentsOfClassRoomFullOutPut>(studentOfClassRoom);
        }

        public async Task DeleteAsync(DeleteStudentOfClassRoomInput input)
        {
            var studentOfClassRoom = _studentOfClassRoom.FirstOrDefault(x => x.Id == input.Id);
            if (studentOfClassRoom != null)
            {
                await _studentOfClassRoom.DeleteAsync(studentOfClassRoom);
            }
        }

        public List<StudentsOfClassRoomFullOutPut> Get(GetStudentsOfClassRoomInput input)
        {
            List<StudentOfClassRoom.StudentOfClassRoom> studentOfClassRoom = null;

            if (input.ClassRoomId > 0)
            {
                studentOfClassRoom = _studentOfClassRoom.GetAllList().Where(x => x.ClassRoom != null && x.ClassRoom.Id == input.ClassRoomId).ToList();
            }
            else
            {
                studentOfClassRoom = _studentOfClassRoom.GetAllList().Where(x => x.User.Id == input.UserId).ToList();
            }

            return ObjectMapper.Map<List<StudentsOfClassRoomFullOutPut>>(studentOfClassRoom);
        }

        public async Task<List<StudentsOfClassRoomFullOutPut>> GetAsync(GetStudentsOfClassRoomInput input)
        {
            List<StudentOfClassRoom.StudentOfClassRoom> studentOfClassRoom = null;

            if (input.ClassRoomId > 0)
            {
                studentOfClassRoom = _studentOfClassRoom.GetAllList().Where(x => x.ClassRoom != null && x.ClassRoom.Id == input.ClassRoomId).ToList();
                //studentOfClassRoom = _studentOfClassRoom.GetAllList().Where(x => x.ClassRoom.Id == input.ClassRoomId).ToList();
            }
            else
            {
                studentOfClassRoom = _studentOfClassRoom.GetAllList().Where(x => x.User != null && x.User.Id == input.UserId).ToList();
            }

            return ObjectMapper.Map<List<StudentsOfClassRoomFullOutPut>>(studentOfClassRoom);
        }

        public async Task<List<StudentsOfClassRoomFullOutPut>> GetListAsync()
        {
            var studentsOfClassRoom = await _studentOfClassRoom.GetAllListAsync();
            return ObjectMapper.Map<List<StudentsOfClassRoomFullOutPut>>(studentsOfClassRoom);
        }

        public async Task<StudentsOfClassRoomFullOutPut> UpdateAsync(UpdateStudentOfClassRoomInput input)
        {
            StudentOfClassRoom.StudentOfClassRoom studentOfClassRoom = null;

            if (input.ClassRoomId > 0)
            {
                studentOfClassRoom = _studentOfClassRoom.Get(input.ClassRoomId);
            }
            else
            {
                studentOfClassRoom = _studentOfClassRoom.Get(input.UserId);
            }

            return null;
        }
    }
}
