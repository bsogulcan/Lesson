using Abp.Application.Services;
using Lesson.Domain.Exams.Exam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.Exam
{
    public interface IExamApplicationService:IApplicationService
    {
        Task<ExaminationsFullOutPut> CreateAsync(CreateExamInput input);
        Task<List<ExaminationsFullOutPut>> GetListAsync();
        Task<ExaminationsFullOutPut> GetAsync(GetExaminationInput input);
    }
}
