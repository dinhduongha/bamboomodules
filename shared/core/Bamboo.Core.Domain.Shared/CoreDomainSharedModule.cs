using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Bamboo.Core.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Bamboo.Shared.Common;

namespace Bamboo.Core;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpSharedCommonModule)
)]
public class CoreDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CoreDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CoreResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/Core");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("Core", typeof(CoreResource));
        });
    }
}
