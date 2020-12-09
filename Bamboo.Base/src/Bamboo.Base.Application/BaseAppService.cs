using Bamboo.Base.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.Base
{
    public abstract class BaseAppService : ApplicationService
    {
        protected BaseAppService()
        {
            LocalizationResource = typeof(BaseResource);
            ObjectMapperContext = typeof(BaseApplicationModule);
        }
    }
}
