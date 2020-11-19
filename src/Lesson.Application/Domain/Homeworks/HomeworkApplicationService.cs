using Abp;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Notifications;
using Lesson.Authorization.Users;
using Lesson.Classes;
using Lesson.Domain.Homeworks.Dto;
using Lesson.Domain.Lessons;
using Lesson.Manager;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.Homeworks
{
    public class HomeworkApplicationService : ApplicationService, IHomeworkApplicationService
    {
        readonly IRepository<Homework> _homeworkRepository;
        private readonly IEntityManager _entityManager;
        private readonly UserManager _userManager;


        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly INotificationPublisher _notificationPublisher;


        public HomeworkApplicationService(IRepository<Homework> homeworkRepository,
            IEntityManager entityManager,
            UserManager userManager,
            INotificationSubscriptionManager notificationSubscriptionManager,
            INotificationPublisher notificationPublisher)
        {
            _homeworkRepository = homeworkRepository;
            _entityManager = entityManager;
            _userManager = userManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _notificationPublisher = notificationPublisher;
        }

        public async Task<HomeworkFullOutPut> CreateAsync(CreateHomeworkInput input)
        {
            var homework = new Homework
            {
                Summary = input.Summary,
                Description = input.Description,
                Lesson = await _entityManager.GetLessonAsync(input.Lesson.Id),
                ClassRoom = await _entityManager.GetClassRoomAsync(input.ClassRoom.Id),
                User = await _userManager.GetUserByIdAsync(input.User.Id),
                Deadline = input.Deadline
            };

            homework.Id = _homeworkRepository.InsertAndGetId(homework);
            Publish_Homeworks(new UserIdentifier(null, 1));
            return ObjectMapper.Map<HomeworkFullOutPut>(homework);
        }

        public async Task DeleteAsync(DeleteHomeworkInput input)
        {
            var homework = await _entityManager.GetHomeworkAsync(input.Id);
            await _homeworkRepository.DeleteAsync(homework);
        }

        public async Task<HomeworkFullOutPut> GetAsync(GetHomeworkInput input)
        {
            var homework = await _entityManager.GetHomeworkAsync(input.Id);
            return ObjectMapper.Map<HomeworkFullOutPut>(homework);
        }

        public async Task<List<HomeworkFullOutPut>> GetListAsync()
        {
            var homeworks = await _homeworkRepository.GetAllListAsync();
            return ObjectMapper.Map<List<HomeworkFullOutPut>>(homeworks);
        }

        public List<HomeworkFullOutPut> GetListByStudents(GetHomeworkInput input)
        {
            var studentsClasses = _entityManager.GetClassRoomsByStudents((int)input.User.Id);
            List<HomeworkFullOutPut> homeworks = new List<HomeworkFullOutPut>();

            foreach (var studentsClass in studentsClasses)
            {
                var homeworksOfClassRoom = _homeworkRepository.GetAllList().Where(x => x.ClassRoom != null && x.ClassRoom.Id == studentsClass.ClassRoom.Id).ToList();
                foreach (var homework in homeworksOfClassRoom)
                {
                    homeworks.Add(new HomeworkFullOutPut
                    {
                        ClassRoom = homework.ClassRoom,
                        Deadline = homework.Deadline,
                        Description = homework.Description,
                        Id = homework.Id,
                        Lesson = homework.Lesson,
                        Summary = homework.Summary,
                        User = homework.User
                    });
                } 
            }
            return homeworks;
        }
        public async Task<HomeworkFullOutPut> UpdateAsync(UpdateHomeworkInput input)
        {
            var homework = await _entityManager.GetHomeworkAsync(input.Id);
            homework.Summary = input.Summary;
            homework.Description = input.Description;
            homework.Lesson = input.Lesson;
            homework.ClassRoom = input.ClassRoom;
            homework.User = input.User;
            homework.Deadline = input.Deadline;

            await _homeworkRepository.UpdateAsync(homework);

            return ObjectMapper.Map<HomeworkFullOutPut>(homework);
        }
        public async Task Subscribe_Homeworks(int userId)
        {
            await _notificationSubscriptionManager.SubscribeAsync(new UserIdentifier(null, userId), "HomeworkInfo");
        }

        public async Task Publish_Homeworks(UserIdentifier targetUserId)
        {
            await _notificationPublisher.PublishAsync("HomeworkInfo", new SentHomeworkInfoNotificationData("Test")  , userIds: new[] { targetUserId });
        }
    }
} 