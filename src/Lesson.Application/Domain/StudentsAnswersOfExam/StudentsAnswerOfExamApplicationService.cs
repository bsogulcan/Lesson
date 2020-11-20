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

        public async Task CreateAsync(CreateStudentsAnswerOfExamInput input)
        {
            var studentsAnswerOfExam = new Lesson.Domain.StudentsAnswerOfExam.StudentsAnswerOfExam
            {
                User = await _userManager.GetUserByIdAsync(input.UserId),
                Examination = await _examinationRepository.GetAsync(input.ExaminationId),
                ExaminationQuestion = await _examinationQuestionRepository.GetAsync(input.ExaminationQuestionId),
                ExaminationQuestionAnswer = await _examinationQuestionAnswerRepository.GetAsync(input.ExaminationQuestionAnswerId)
            };

            studentsAnswerOfExam.Id = await _studentsAnswerOfExamRepository.InsertAndGetIdAsync(studentsAnswerOfExam);
        }

        public List<StudentsAnswerOfExamFullOutPut> GetAnswersByExam(GetStudentsAnswerOfExamInput input)
        {
            var studentsAnswersOfExam = _studentsAnswerOfExamRepository.GetAllList().Where(x => x.User.Id == input.UserId && x.Examination.Id == input.ExaminationId).ToList();
            return ObjectMapper.Map<List<StudentsAnswerOfExamFullOutPut>>(studentsAnswersOfExam);
        }

        public bool IsUserApprovedExam(GetStudentsAnswerOfExamInput input)
        { 
            return _studentsAnswerOfExamRepository.GetAllList().Where(x => x.User.Id == input.UserId && x.Examination.Id == input.ExaminationId).ToList().Count > 0 ? true : false;
        }
    }
}
