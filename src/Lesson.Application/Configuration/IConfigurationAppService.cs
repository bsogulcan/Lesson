using System.Threading.Tasks;
using Abp.Application.Services;
using Lesson.Configuration.Dto;

namespace Lesson.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}