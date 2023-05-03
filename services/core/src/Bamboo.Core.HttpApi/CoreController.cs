using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Bamboo.Core;

public abstract class CoreController : AbpControllerBase
{
    protected CoreController()
    {
        LocalizationResource = typeof(CoreResource);
    }
}
