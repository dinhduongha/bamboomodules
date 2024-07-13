using Bamboo.Admin.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Bamboo.Blazor.Client;

public abstract class BambooComponentBase : AbpComponentBase
{
    protected BambooComponentBase()
    {
        LocalizationResource = typeof(AdminResource);
    }
}
