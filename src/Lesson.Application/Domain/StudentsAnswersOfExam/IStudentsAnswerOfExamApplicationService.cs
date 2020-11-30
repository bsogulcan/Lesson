using Abp.Application.Services;
using Lesson.Domain.StudentsAnswersOfExam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsAnswersOfExam
{
    public interface IStudentsAnswerOfExamApplicationService:IApplicationService
    {
        Task<StudentsAnswerOfExamFullOutPut> CreateAsync(CreateStudentsAnswerOfExamInput input);
        List<StudentsAnswerOfExamFullOutPut> GetAnswersByExam(GetStudentsAnswerOfExamInput input);
        bool IsUserApprovedExam(GetStudentsAnswerOfExamInput input);
    }
}
