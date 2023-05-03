using Bamboo.Core.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Core;

public abstract class CoreAppService : ApplicationService
{
    protected CoreAppService()
    {
        LocalizationResource = typeof(CoreResource);
        ObjectMapperContext = typeof(CoreApplicationModule);
    }
}
