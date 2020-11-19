using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lesson.MultiTenancy.Dto;

namespace Lesson.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
