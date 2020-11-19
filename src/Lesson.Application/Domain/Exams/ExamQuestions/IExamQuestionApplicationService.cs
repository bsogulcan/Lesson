using Abp.Application.Services;
using Lesson.Domain.Exams.ExamQuestions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.ExamQuestions
{
    public interface IExamQuestionApplicationService:IApplicationService
    {
        Task CreateAsync(CreateExamQuestionInput input);
        Task<List<ExamQuestionFullOutPut>> GetQuestionsByExamId(GetExamQuestionInput input);
    }
}
