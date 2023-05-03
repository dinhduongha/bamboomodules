using Bamboo.Core.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Bamboo.Core.Blazor.Server.Host;

public abstract class CoreComponentBase : AbpComponentBase
{
    protected CoreComponentBase()
    {
        LocalizationResource = typeof(CoreResource);
    }
}
