using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Guids;
using Volo.Abp.Modularity;

namespace Bamboo.Shared.Common
{
    public class AbpSharedCommonModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.Replace(ServiceDescriptor.Transient<IGuidGenerator, MySequentialGuidGenerator>());
        }
    }
}