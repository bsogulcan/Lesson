using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Domain.Exams.ExamQuestions;
using Lesson.Domain.Exams.ExamQuestions.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Exams.ExamQuestion
{
    public class ExamQuestionApplicationService : ApplicationService, IExamQuestionApplicationService
    {
        private readonly IRepository<ExaminationQuestion> _examQuestionRepository;
        public ExamQuestionApplicationService(IRepository<ExaminationQuestion> examQuestionRepository)
        {
            _examQuestionRepository = examQuestionRepository;
        }

        public async Task CreateAsync(CreateExamQuestionInput input)
        {
            var examQuestion = new ExaminationQuestion
            {
                Question = input.Question,
                Answers = input.Answers
            };

            examQuestion.Id = await _examQuestionRepository.InsertAndGetIdAsync(examQuestion);
        }
    }
}