using Bamboo.CRM.Localization;
using Volo.Abp.Application.Services;

namespace Bamboo.CRM
{
    public abstract class CRMAppService : ApplicationService
    {
        protected CRMAppService()
        {
            LocalizationResource = typeof(CRMResource);
            ObjectMapperContext = typeof(CRMApplicationModule);
        }
    }
}
