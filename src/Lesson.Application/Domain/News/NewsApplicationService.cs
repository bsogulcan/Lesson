using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using Lesson.Domain.News.Dto;
using Lesson.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson.Domain.News
{
    public class NewsApplicationService : ApplicationService, INewsApplicationService
    {
        private readonly IRepository<News> _newsRepository;
        private readonly EntityManager _entityManager;

        public NewsApplicationService(IRepository<News> newsRepository,
            EntityManager entityManager)
        {
            _newsRepository = newsRepository;
            _entityManager = entityManager;
        }

        public async Task<NewsFullOutPut> CreateAsync(CreateNewsInput input)
        {
            var news = new News
            {
                Summary = input.Summary,
                Content = input.Content
            };

            news = await _newsRepository.InsertAsync(news);
            return ObjectMapper.Map<NewsFullOutPut>(news);
        }

        public async Task<NewsFullOutPut> GetAsync(GetNewsInput input)
        {
            var news = await _newsRepository.GetAsync(input.Id);
            if (news == null)
            {
                throw new UserFriendlyException("There is no entity about News");
            }

            return ObjectMapper.Map<NewsFullOutPut>(news);
        }

        public async Task<List<NewsFullOutPut>> GetListAsync()
        {
            var newsList = await _newsRepository.GetAllListAsync();
            var newsFullOutPutList = new List<NewsFullOutPut>();
            foreach (var news in newsList)
            {
                var newsFullOutPut = ObjectMapper.Map<NewsFullOutPut>(news);
                newsFullOutPut.User = _entityManager.GetUserByIdSync(news.CreatorUserId??default(int));
                newsFullOutPut.CreateionTime = news.CreationTime;
                newsFullOutPutList.Add(newsFullOutPut);
            }

            return newsFullOutPutList.OrderByDescending(x=>x.CreateionTime).ToList();
        }

        public List<NewsFullOutPut> Search(GetNewsInput input)
        {
            var newsList = _newsRepository.GetAllList(x => x.Summary.Contains(input.Summary));
            var newsFullOutPutList = new List<NewsFullOutPut>();
            foreach (var news in newsList)
            {
                var newsFullOutPut = ObjectMapper.Map<NewsFullOutPut>(news);
                newsFullOutPut.User = _entityManager.GetUserByIdSync(news.CreatorUserId ?? default(int));
                newsFullOutPut.CreateionTime = news.CreationTime;
                newsFullOutPutList.Add(newsFullOutPut);
            }
             
            return newsFullOutPutList;
        }

        public async Task<NewsFullOutPut> UpdateAsync(UpdateNewsInput input)
        {
            var news = await _newsRepository.GetAsync(input.Id);
            if (news == null)
            {
                throw new UserFriendlyException("There is no entity about News");
            }
            news.Summary = input.Summary;
            news.Content = input.Content;

            await _newsRepository.UpdateAsync(news);
            return ObjectMapper.Map<NewsFullOutPut>(news);
        }
    }
}
