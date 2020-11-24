using Abp.Application.Services;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.ObjectMapping;
using Abp.UI;
using Lesson.Authorization;
using Lesson.Categories;
using Lesson.Classes.Dto;
using Lesson.Domain.Classes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Classes
{
    //[AbpAuthorize(PermissionNames.ClassRoom)]
    public class ClassRoomAppService : ApplicationService, IClassRoomAppService
    {
        private readonly IRepository<ClassRoom> _classRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public ClassRoomAppService(IRepository<ClassRoom> classRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _classRepository = classRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }

        //[AbpAuthorize(PermissionNames.ClassRoom_Create)]
        public async Task<ClassRoomFullOutPut> CreateAsync(CreateClassRoomInput input)
        {
            var newClassRoom = new ClassRoom
            {
                Name = input.Name,
                Branch = input.Branch,
                Description = input.Description
            };

            await _classRepository.InsertAsync(newClassRoom);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            return ObjectMapper.Map<ClassRoomFullOutPut>(newClassRoom);
        }

        //[AbpAuthorize(PermissionNames.ClassRoom_Delete)]
        public async Task Delete(DeleteClassRoomInput input)
        {
            var classRoom = await _classRepository.GetAsync(input.Id);
            if (classRoom == null)
                throw new UserFriendlyException("The Class room to be deleted could not be found.");

            await _classRepository.DeleteAsync(classRoom.Id);

            await _unitOfWorkManager.Current.SaveChangesAsync();
        }

        //[AbpAuthorize(PermissionNames.ClassRoom_Get)]
        public async Task<ClassRoomFullOutPut> GetAsync(GetClassRoomInput input)
        {
            var classRoom = await _classRepository.GetAsync(input.Id);
            return ObjectMapper.Map<ClassRoomFullOutPut>(classRoom);
        }

        //[AbpAuthorize(PermissionNames.ClassRoom_GetList)]
        public async Task<List<ClassRoomFullOutPut>> GetListAsync()
        {
            var classRoom = await _classRepository.GetAllListAsync();
            return ObjectMapper.Map<List<ClassRoomFullOutPut>>(classRoom);
        }

        //[AbpAuthorize(PermissionNames.ClassRoom_Update)]
        public async Task<ClassRoomFullOutPut> UpdateAsync(EditClassRoomInput input)
        {
            var classRoom = await _classRepository.GetAsync(input.Id);

            if (classRoom==null)
                throw new UserFriendlyException("The Class room to be updated could not be found.");
             
            classRoom.Name = input.Name;
            classRoom.Branch = input.Branch;
            classRoom.Description = input.Description;

            await _classRepository.UpdateAsync(classRoom);
            await _unitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<ClassRoomFullOutPut>(classRoom);
        }
    }
}
