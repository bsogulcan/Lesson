using Abp.Application.Services;
using Lesson.Classes.Dto;
using Lesson.Domain.Classes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Classes
{
    public interface IClassRoomAppService: IApplicationService
    {
        Task<ClassRoomFullOutPut> CreateAsync(CreateClassRoomInput input);
        Task<ClassRoomFullOutPut> GetAsync(GetClassRoomInput input);
        Task<List<Dto.ClassRoomFullOutPut>> GetListAsync();
        Task<ClassRoomFullOutPut> UpdateAsync(EditClassRoomInput input);
        Task Delete(DeleteClassRoomInput input);
    }
}
