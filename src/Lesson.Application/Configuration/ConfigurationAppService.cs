using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Lesson.Configuration.Dto;

namespace Lesson.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LessonAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
