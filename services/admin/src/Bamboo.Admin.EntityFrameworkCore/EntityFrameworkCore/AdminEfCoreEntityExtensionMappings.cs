using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;
using Volo.Abp.TenantManagement;
using Volo.Abp.OpenIddict.Applications;

namespace Bamboo.Admin.EntityFrameworkCore;

public static class AdminEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        AdminGlobalFeatureConfigurator.Configure();
        AdminModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            /* You can configure extra properties for the
             * entities defined in the modules used by your application.
             *
             * This class can be used to map these extra properties to table fields in the database.
             *
             * USE THIS CLASS ONLY TO CONFIGURE EF CORE RELATED MAPPING.
             * USE AdminModuleExtensionConfigurator CLASS (in the Domain.Shared project)
             * FOR A HIGH LEVEL API TO DEFINE EXTRA PROPERTIES TO ENTITIES OF THE USED MODULES
             *
             * Example: Map a property to a table field:

                 ObjectExtensionManager.Instance
                     .MapEfCoreProperty<IdentityUser, string>(
                         "MyProperty",
                         (entityBuilder, propertyBuilder) =>
                         {
                             propertyBuilder.HasMaxLength(128);
                         }
                     );

             * See the documentation for more:
             * https://docs.abp.io/en/abp/latest/Customizing-Application-Modules-Extending-Entities
             */
            // ObjectExtensionManager.Instance
            //     .MapEfCoreProperty<IdentityUser, Guid?>("PublicId");

            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, Guid?>("BranchId");
            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, long>("MaxTenant", (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasDefaultValue(1);
                });
            ObjectExtensionManager.Instance
                .MapEfCoreProperty<IdentityUser, long>("Vip",
                (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasDefaultValue(0);
                });

            ObjectExtensionManager.Instance
                .MapEfCoreProperty<Tenant, Guid?>("OwnerId")
                .MapEfCoreProperty<Tenant, Guid?>("ParentId")
                .MapEfCoreProperty<Tenant, long>("MaxChild", (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasDefaultValue(0);
                })
                .MapEfCoreProperty<Tenant, long>("VipLevel", (entityBuilder, propertyBuilder) =>
                {
                    propertyBuilder.HasDefaultValue(0);
                })
                .MapEfCoreProperty<Tenant, string>("Host")
                .MapEfCoreProperty<Tenant, string>("ParentPath")
                .MapEfCoreProperty<Tenant, string?>("Description");

            ObjectExtensionManager.Instance
                .MapEfCoreProperty<OpenIddictApplication, Guid?>("TenantId");

            // ObjectExtensionManager.Instance
            //     .MapEfCoreProperty<IdentityUserLogin, string?>("ProviderUid");
            // ObjectExtensionManager.Instance
            //     .MapEfCoreProperty<IdentityUserLogin, string?>("ProviderName");            

        });
    }
}
