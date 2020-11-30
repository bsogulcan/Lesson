using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Lesson.Domain.VideoContent.Dto;
using Lesson.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.VideoContent
{
    public class VideoContentApplicationService : ApplicationService, IVideoContentApplicationService
    {
        private readonly IRepository<VideoContent> _videoContentRepository;
        private readonly IEntityManager _entityManager;

        public VideoContentApplicationService(IRepository<VideoContent> videoContentRepository,
            IEntityManager entityManager)
        {
            _videoContentRepository = videoContentRepository;
            _entityManager = entityManager;
        }

        public async Task<VideoContentFullOutPut> CreateAsync(CreateVideoContentInput input)
        {
            var videoContent = new VideoContent
            {
                HomeworkId=input.HomeWorkId,
                Summary = input.Summary,
                Content = Convert.FromBase64String(input.FileBase64),
                VideoName = input.VideoName,
                VideoSize = input.VideoSize
            };

            await _videoContentRepository.InsertAsync(videoContent);
            return ObjectMapper.Map<VideoContentFullOutPut>(videoContent);

        }

        public async Task<VideoContentFullOutPut> GetAsync(GetVideoContentInput input)
        {
            var videoContent = await _videoContentRepository.GetAsync(input.Id);
            if (videoContent==null)
            {
                throw new UserFriendlyException("There isnt any video content");
            }
            return ObjectMapper.Map<VideoContentFullOutPut>(videoContent);
        }

        public async Task<List<VideoContentFullOutPut>> GetListAsync()
        {
            var videoContents = await _videoContentRepository.GetAllListAsync();
            return ObjectMapper.Map<List<VideoContentFullOutPut>>(videoContents);
        }

        public VideoContentFullOutPut GetVideoContentByHomeworkId(GetVideoContentInput input)
        {
            var videoContent = _videoContentRepository.GetAllList(x => x.HomeworkId == input.HomeworkId).FirstOrDefault();
            if (videoContent == null)
            {
                throw new UserFriendlyException("There isnt any video content");
            }
            return ObjectMapper.Map<VideoContentFullOutPut>(videoContent);
        }
    }
}
