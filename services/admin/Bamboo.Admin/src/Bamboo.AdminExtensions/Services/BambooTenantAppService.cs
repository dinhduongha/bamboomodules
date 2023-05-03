using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;
using Volo.Abp.Validation;

[Dependency(ReplaceServices = true)]
[ExposeServices(typeof(ITenantAppService), typeof(TenantAppService), typeof(BambooTenantAppService))]
public class BambooTenantAppService : TenantAppService
{
    protected IDataFilter _dataFilter;
    protected IIdentityUserRepository UserRepository { get; }
    protected IdentityUserManager UserManager { get; }
    protected ILookupNormalizer LookupNormalizer { get; }

    public BambooTenantAppService(
        IDataFilter dataFilter,
        ITenantRepository tenantRepository,
        ITenantManager tenantManager,
        IDataSeeder dataSeeder,
        IDistributedEventBus distributedEventBus
    ) : base(
        tenantRepository,
        tenantManager,
        dataSeeder,
        distributedEventBus)
    {
        _dataFilter = dataFilter;
    }

    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public async override Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new AbpValidationException(
                "Not allow to create new tenant!"
            );
        }
        return await base.CreateAsync(input);
    }

    [Authorize(TenantManagementPermissions.Tenants.Create)]
    public async Task<TenantDto> CreateAsync2(TenantCreateDto input)
    {
        // Email: @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"
        // Name: @"^[a-zA-Z0-9]*$"
        if (!Regex.Match(input.Name, @"^[a-zA-Z0-9]*$").Success)
        {
            throw new UserFriendlyException($"Tenant name is invalid");
        }

        if (!ValidationHelper.IsValidEmailAddress(input.AdminEmailAddress))
        {
            throw new UserFriendlyException($"Admin email address is invalid");
        }

        var lst = await TenantRepository.GetListAsync(filter: input.Name);
        if (lst.Count > 0)
        {
            throw new UserFriendlyException($"Tenant exists");
        }

        using (_dataFilter.Disable<IMultiTenant>())
        {

            var lstUser = await UserRepository.GetListAsync(filter: input.AdminEmailAddress);
            if (lstUser.Count > 0)
            {
                var exist = lstUser.Where(x => x.Email == input.AdminEmailAddress).FirstOrDefault();
                if (exist != null)
                {
                    throw new AbpValidationException(
                    "Email is used!",
                    new List<ValidationResult>
                    {
                                new ValidationResult(
                                    "Admin email already in used!",
                                    new []{"Admin Email"}
                                )
                    }
                );
                }
            }
        }
        var tenant = await TenantManager.CreateAsync(input.Name);
        input.MapExtraPropertiesTo(tenant);

        await TenantRepository.InsertAsync(tenant);

        await CurrentUnitOfWork.SaveChangesAsync();

        using (CurrentTenant.Change(tenant.Id, tenant.Name))
        {
            //TODO: Handle database creation?

            await DataSeeder.SeedAsync(
                            new DataSeedContext(tenant.Id)
                                .WithProperty("AdminEmail", input.AdminEmailAddress)
                                .WithProperty("AdminPassword", input.AdminPassword)
                            );
            //"admin" user
            const string adminUserName = "admin";
            var adminUser = await UserRepository.FindByNormalizedUserNameAsync(
                LookupNormalizer.NormalizeName(adminUserName)
            );

            if (adminUser != null)
            {
                (await UserManager.SetUserNameAsync(adminUser, input.Name)).CheckErrors();

                (await UserManager.UpdateAsync(adminUser)).CheckErrors();
                await CurrentUnitOfWork.SaveChangesAsync();
            }
        }
        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    }
}