using System.Threading.Tasks;
using Abp.Application.Services;
using Lesson.Sessions.Dto;

namespace Lesson.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
