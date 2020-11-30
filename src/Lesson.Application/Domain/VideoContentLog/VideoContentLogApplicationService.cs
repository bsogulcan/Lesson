using Abp.Application.Services;
using Abp.Domain.Repositories;
using Lesson.Domain.VideoContentLog.Dto;
using Lesson.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContentLog
{
    public class VideoContentLogApplicationService : ApplicationService, IVideoContentLogApplicationService
    {
        private readonly IRepository<Lesson.Domain.VideoContent.VideoContentLog> _videoContentLogRepository;
        private readonly IEntityManager _entityManager;
        private readonly IRepository<Lesson.Domain.VideoContent.VideoContent> _videoContentRepository;

        public VideoContentLogApplicationService(IRepository<Lesson.Domain.VideoContent.VideoContentLog> videoContentLogRepository,
            IEntityManager entityManager,
            IRepository<Lesson.Domain.VideoContent.VideoContent> videoContentRepository)
        {
            _videoContentLogRepository = videoContentLogRepository;
            _entityManager = entityManager;
            _videoContentRepository = videoContentRepository;

        }
        public async Task<VideoContentLogFullOutPut> CreateAsync(CreateVideoContentLogInput input)
        {
            var videoContentLog = new VideoContent.VideoContentLog
            {
                User = await _entityManager.GetUserById(AbpSession.UserId.Value),
                Log = input.Log,
                IsCompleted = input.IsCompleted,
                VideoContentId = input.VideoContentId,
            };

            await _videoContentLogRepository.InsertAsync(videoContentLog);
            return ObjectMapper.Map<VideoContentLogFullOutPut>(videoContentLog);
        }

        public Task<List<VideoContentLogFullOutPut>> GetAsync(GetVideoContenLogInput input)
        {
            throw new NotImplementedException();
        }
    }
}
