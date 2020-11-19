using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Domain.Exams.Exam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson.Domain.Exams;
using Lesson.Manager;
using Lesson.Domain.Exams.ExamQuestions;

namespace Lesson.Domain.Exams.Exam
{
    public class ExamApplicationService : ApplicationService, IExamApplicationService
    {
        private readonly IRepository<Examination> _examRepository;
        private readonly IEntityManager _entityManager;
        private readonly IExamQuestionApplicationService _examQuestionApplicationService;
        public ExamApplicationService(IRepository<Examination> examRepository,
            IEntityManager entityManager,
            IExamQuestionApplicationService examQuestionApplicationService)
        {
            _examRepository = examRepository;
            _entityManager = entityManager;
            _examQuestionApplicationService = examQuestionApplicationService;
        }
        public async Task CreateAsync(CreateExamInput input)
        {
            var exam = new Examination
            {
                Name = input.Name,
                StartDate = input.StartDate,
                EndDate = input.EndDate,
                ClassRoom = await _entityManager.GetClassRoomAsync(input.ClassRoomId),
                Lesson = await _entityManager.GetLessonAsync(input.LessonId),
                User = await _entityManager.GetUserById(input.UserId),
                TimeLimit=input.TimeLimit,
                Questions=input.Questions
            };

            exam.Id = await _examRepository.InsertAndGetIdAsync(exam); 
        }

        public ExaminationsFullOutPut Get(GetExaminationInput input)
        {
            var exam = _examRepository.Get(input.Id);
            return ObjectMapper.Map<ExaminationsFullOutPut>(exam);
        }

        public async Task<List<ExaminationsFullOutPut>> GetListAsync()
        {
            var exams =await _examRepository.GetAllListAsync();
            return ObjectMapper.Map<List<ExaminationsFullOutPut>>(exams);
        }
    }
}
