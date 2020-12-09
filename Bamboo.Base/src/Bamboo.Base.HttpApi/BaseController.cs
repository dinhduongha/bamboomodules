using Bamboo.Base.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Base
{
    public abstract class BaseController : AbpController
    {
        protected BaseController()
        {
            LocalizationResource = typeof(BaseResource);
        }
    }
}
