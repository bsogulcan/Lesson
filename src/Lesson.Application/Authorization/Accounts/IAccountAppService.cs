using System.Threading.Tasks;
using Abp.Application.Services;
using Lesson.Authorization.Accounts.Dto;

namespace Lesson.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
