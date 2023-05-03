using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

[Dependency(ReplaceServices = true)]
public class AbpSharedBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "AbpSharedApplication";
}
