using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

using Abp.AspNetCore;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.AspNetCore.Configuration;
using Abp.Threading.BackgroundWorkers;

namespace Bamboo.Base
{
    [DependsOn(
     //  typeof(BambooCoreModule),
     //typeof(BambooEntityFrameworkModule),
     //typeof(AbpAutoMapperModule),
     //typeof(BambooApplicationModule),
     //typeof(BambooWebCoreModule),
     typeof(AbpAspNetCoreModule)
    )]

    public class BambooBaseApplicationModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BambooBaseApplicationModule(IWebHostEnvironment env)
        {
            _env = env;
            //_appConfiguration = env.GetAppConfiguration();
        }
        public override void PreInitialize()
        {
            //Configuration.Authorization.Providers.Add<BambooAuthorizationProvider>();
            Configuration.Modules.AbpAspNetCore()
                .CreateControllersForAppServices(typeof(BambooBaseApplicationModule).GetAssembly());
        }
        public override void Initialize()
        {

            var thisAssembly = typeof(BambooBaseApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );

        }
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                    .AddApplicationPartsIfNotAddedBefore(typeof(BambooBaseApplicationModule).Assembly);
        }
    }
}