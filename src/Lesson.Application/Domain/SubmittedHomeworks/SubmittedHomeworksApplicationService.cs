using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Lesson.Domain.SubmittedHomeworks.Dto;
using Lesson.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.SubmittedHomeworks
{
    public class SubmittedHomeworksApplicationService : ApplicationService, ISubmittedHomeworksApplicationService
    {
        private readonly IRepository<SubmittedHomeworks> _submittedHomeworks;
        private readonly EntityManager _entityManager;
        public SubmittedHomeworksApplicationService(IRepository<SubmittedHomeworks> submittedHomeworks,
            EntityManager entityManager)
        {
            _submittedHomeworks = submittedHomeworks;
            _entityManager = entityManager;
        }

        public async Task<SubmittedHomeworksFullOutPut> CreateAsync(CreateSubmittedHomeworkInput input)
        {
            var submittedHomework = new SubmittedHomeworks
            {
                File = input.File,
                Name = input.Name,
                Type = input.Type,
                Size = input.Size,
                User = await _entityManager.GetUserById(input.UserId),
                Homework = await _entityManager.GetHomeworkAsync(input.HomeworkId)
            };

            submittedHomework.Id = await _submittedHomeworks.InsertAndGetIdAsync(submittedHomework);
            return ObjectMapper.Map<SubmittedHomeworksFullOutPut>(submittedHomework);
        }

        public async Task<SubmittedHomeworksFullOutPut> GetAsync(GetSubmittedHomeworkInput input)
        {
            var submittedHomework = await _submittedHomeworks.GetAsync(input.Id);
            if (submittedHomework == null)
            {
                throw new UserFriendlyException("There is no Submitted Homework");
            }

            return ObjectMapper.Map<SubmittedHomeworksFullOutPut>(submittedHomework);
        }

        public List<SubmittedHomeworksFullOutPut> GetByHomework(GetSubmittedHomeworkInput input)
        {
            var submittedHomework = _submittedHomeworks.GetAllIncluding().Where(x => x.Homework.Id == input.HomeworkId).ToList();
            if (submittedHomework == null)
            {
                throw new UserFriendlyException("There is no Submitted Homework");
            }

            return ObjectMapper.Map<List<SubmittedHomeworksFullOutPut>>(submittedHomework);
        }

        public async Task<List<SubmittedHomeworksFullOutPut>> GetListAsync()
        {
            var submittedHomework = await _submittedHomeworks.GetAllListAsync();
            if (submittedHomework == null)
            {
                throw new UserFriendlyException("There is no Submitted Homework");
            }

            return ObjectMapper.Map<List<SubmittedHomeworksFullOutPut>>(submittedHomework);
        }
    }
}
