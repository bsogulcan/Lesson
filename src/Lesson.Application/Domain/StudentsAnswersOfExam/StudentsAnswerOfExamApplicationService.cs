using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Authorization.Users;
using Lesson.Domain.Exams;
using Lesson.Domain.Exams.Exam;
using Lesson.Domain.StudentsAnswersOfExam.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.StudentsAnswersOfExam
{
    public class StudentsAnswerOfExamApplicationService : ApplicationService, IStudentsAnswerOfExamApplicationService
    {
        private readonly IRepository<Lesson.Domain.StudentsAnswerOfExam.StudentsAnswerOfExam> _studentsAnswerOfExamRepository;
        private readonly UserManager _userManager;
        private readonly IRepository<Examination> _examinationRepository;
        private readonly IRepository<ExaminationQuestion> _examinationQuestionRepository;
        private readonly IRepository<ExaminationQuestionAnswer> _examinationQuestionAnswerRepository;

        public StudentsAnswerOfExamApplicationService(IRepository<Lesson.Domain.StudentsAnswerOfExam.StudentsAnswerOfExam> studentsAnswerOfExamRepository,
            UserManager userManager,
            IRepository<Examination> examinationRepository,
            IRepository<ExaminationQuestion> examinationQuestionRepository,
            IRepository<ExaminationQuestionAnswer> examinationQuestionAnswerRepository)
        {
            _studentsAnswerOfExamRepository = studentsAnswerOfExamRepository;
            _userManager = userManager;
            _examinationRepository = examinationRepository;
            _examinationQuestionRepository = examinationQuestionRepository;
            _examinationQuestionAnswerRepository = examinationQuestionAnswerRepository;
        }

        public async Task<StudentsAnswerOfExamFullOutPut> CreateAsync(CreateStudentsAnswerOfExamInput input)
        {
            var studentsAnswerOfExam = new Lesson.Domain.StudentsAnswerOfExam.StudentsAnswerOfExam
            {
                User = await _userManager.GetUserByIdAsync(AbpSession.UserId.Value),
                Examination = await _examinationRepository.GetAsync(input.ExaminationId),
                ExaminationQuestion = await _examinationQuestionRepository.GetAsync(input.ExaminationQuestionId),
                ExaminationQuestionAnswer = await _examinationQuestionAnswerRepository.GetAsync(input.ExaminationQuestionAnswerId)
            };

            studentsAnswerOfExam = await _studentsAnswerOfExamRepository.InsertAsync(studentsAnswerOfExam);
            return ObjectMapper.Map<StudentsAnswerOfExamFullOutPut>(studentsAnswerOfExam);
        }

        public List<StudentsAnswerOfExamFullOutPut> GetAnswersByExam(GetStudentsAnswerOfExamInput input)
        {
            var studentsAnswersOfExam = _studentsAnswerOfExamRepository.GetAllList(x => x.UserId == input.UserId && x.ExaminationId == input.ExaminationId);
            return ObjectMapper.Map<List<StudentsAnswerOfExamFullOutPut>>(studentsAnswersOfExam);
        }

        public bool IsUserApprovedExam(GetStudentsAnswerOfExamInput input)
        {
            return _studentsAnswerOfExamRepository.Count(x => x.User.Id == input.UserId && x.ExaminationId == input.ExaminationId) > 0 ? true : false;
        }
    }
}
