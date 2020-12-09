using Bamboo.CRM.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.CRM
{
    public abstract class CRMController : AbpController
    {
        protected CRMController()
        {
            LocalizationResource = typeof(CRMResource);
        }
    }
}
