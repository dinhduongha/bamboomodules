using System.IO;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Volo.Abp;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.Users;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Identity.EntityFrameworkCore;

using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Bamboo.AdminExtensions;

public class IdentityUserRoleExtension : IdentityUserRole
{
    public IdentityUserRoleExtension(Guid userId, Guid roleId, Guid tenantId)
        : base(userId, roleId, tenantId)
    {
    }
    //public static IdentityUser AddExtRole(this IdentityUser user, Guid roleId, Guid tenantId)
    //{
    //    user.Roles.Add(new IdentityUserRole(user.Id, roleId, tenantId));
    //    return user;
    //}
}

[Authorize]
public class TenantService : ApplicationService
{
    IConfiguration _configuration;

    protected IDistributedEventBus _distributedEventBus { get; }

    protected readonly ITenantManager _tenantManager;
    protected readonly IdentityRoleManager _roleManager;
    protected readonly IdentityUserManager _userManager;
    protected readonly IdentityLinkUserManager _linkManager;

    protected readonly IRepository<Tenant, Guid> _tenantRepository;
    //protected readonly IRepository<IdentityUser, Guid> _userRepository;

    //protected ITenantStore _tenantRepository { get; }
    protected IIdentityRoleRepository _roleRepository { get; }
    protected IIdentityUserRepository _userRepository { get; }
    protected IIdentityLinkUserRepository _identityLinkUserRepository { get; }

    // The below repository not exists
    //protected readonly IRepository<IdentityUserRole> _userRoleRepository;

    protected IHttpClientFactory _httpClientFactory;
    protected IDataSeeder _dataSeeder { get; }
    protected IDataFilter _dataFilter;
    protected IDbContextProvider<IdentityDbContext> _dbContextProvider;

    protected ILookupNormalizer LookupNormalizer { get; }
    //protected AbpSignInManager SignInManager { get; }
    protected AbpUserClaimsPrincipalFactory _abpUserClaimsPrincipalFactory;
    protected ITenantAppService TenantAppService { get; }

    public TenantService(IConfiguration configuration,
                            IDbContextProvider<IdentityDbContext> dbContextProvider,
                            IDistributedEventBus distributedEventBus,
                            ITenantManager tenantManager,
                            IdentityRoleManager roleManager,
                            IdentityUserManager userManager,
                            IdentityLinkUserManager linkManager,
                            IRepository<Tenant, Guid> tenantRepository,
                            IIdentityRoleRepository roleRepository,
                            IIdentityUserRepository userRepository,
                            IIdentityLinkUserRepository identityLinkUserRepository,
                            //AbpSignInManager signInManager,
                            IDataSeeder dataSeeder,
                            IDataFilter dataFilter,
                            AbpUserClaimsPrincipalFactory abpUserClaimsPrincipalFactory,
                            ILookupNormalizer lookupNormalizer,
                            ITenantAppService tenantAppService,
                            IHttpClientFactory httpClientFactory)
    {
        _configuration = configuration;
        _tenantManager = tenantManager;
        _roleManager = roleManager;
        _userManager = userManager;
        _linkManager = linkManager;
        _tenantRepository = tenantRepository;
        _roleRepository = roleRepository;
        _userRepository = userRepository;
        _identityLinkUserRepository = identityLinkUserRepository;
        _abpUserClaimsPrincipalFactory = abpUserClaimsPrincipalFactory;
        _dbContextProvider = dbContextProvider;
        _dataFilter = dataFilter;
        _dataSeeder = dataSeeder;
        _httpClientFactory = httpClientFactory;
        _distributedEventBus = distributedEventBus;
        //SignInManager = signInManager;
        TenantAppService = tenantAppService;
        //_linkAppService = linkAppService;
        LookupNormalizer = lookupNormalizer;
    }

    public async Task<TenantDto> GetAsync(Guid id)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host user can reade tenant");
        }
        var queryable = (await _tenantRepository.GetQueryableAsync()).WhereIf(
                    true,
                    author => author.CreatorId == CurrentUser.Id
                );
        var tenant = queryable.FirstOrDefault();
        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    }

    public async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host user can get tenant");
        }

        using (_dataFilter.Disable<IMultiTenant>())
        {

            var queryable = (await _tenantRepository.GetQueryableAsync()).WhereIf(
                    true,
                    tenant => tenant.CreatorId == CurrentUser.Id
                );
            var tenants = queryable.ToList();
            var totalCount = queryable.LongCount();
            return new PagedResultDto<TenantDto>(
                totalCount,
                ObjectMapper.Map<List<Tenant>, List<TenantDto>>(tenants)
            );
        }
    }

    public async Task<TenantDto> CreateAsync(string name)
    {
        TenantCreateDto input = new TenantCreateDto()
        {
            Name = name,
            AdminEmailAddress = CurrentUser.Email,
            AdminPassword = GuidGenerator.Create().ToString(),
        };
        if (CurrentUser.TenantId != null)
        {
            throw new UserFriendlyException("Only host user can create tenant");
        }

        if (!Regex.Match(input.Name, @"^[a-zA-Z0-9]*$").Success)
        {
            throw new UserFriendlyException($"Name is invalid");
        }

        var tenant = await _tenantRepository.FirstOrDefaultAsync(tenant => tenant.Name == input.Name); // .WhereIf(true, tenant => tenant.) .FindByNameAsync(input.Name);
        if (tenant != null)
        {
            if (tenant.CreatorId == CurrentUser.Id)
            {
                //await _distributedEventBus.PublishAsync(
                //new TenantCreatedEto
                //{
                //    Id = tenant.Id,
                //    Name = tenant.Name,
                //    //Properties = tenant.ExtraProperties.ToDictionary<string, string>(),
                //});
                return ObjectMapper.Map<Tenant, TenantDto>(tenant);
            }
            throw new UserFriendlyException("Name is exist");
        }
        var count = await _tenantRepository.CountAsync(x => x.CreatorId == CurrentUser.Id);
        var maxTenant = _configuration.GetValue<int>("App:MaxTenantPerAccount", 10);
        if (count >= maxTenant)
        {
            throw new UserFriendlyException($"Too many vendors created");
        }
        try
        {
            tenant = await _tenantManager.CreateAsync(input.Name);
            input.SetProperty("admin", input.AdminEmailAddress);
            input.MapExtraPropertiesTo(tenant);
            tenant.CreatorId = CurrentUser.Id;
            tenant.SetProperty("email", input.AdminEmailAddress);
            tenant.SetProperty("creator", CurrentUser.Id);
            tenant = await _tenantRepository.InsertAsync(tenant);
            await CurrentUnitOfWork.SaveChangesAsync();

            var currentUser = await _userRepository.GetAsync((Guid)CurrentUser.Id);

            var user = new IdentityLinkUserInfo((Guid)CurrentUser.Id, null);
            using (CurrentTenant.Change(null))
            {
            }
            using (CurrentTenant.Change(tenant.Id, tenant.Name))
            {
                await _dataSeeder.SeedAsync(new DataSeedContext(tenant.Id)
                    //.WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, $"{input.Name}@{input.Name}.Bamboo.io")
                    .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, $"{input.AdminEmailAddress}")
                    .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, $"{input.AdminPassword}")
                    );
                //"admin" user
                const string adminUserName = "admin";
                var adminUser = await _userRepository.FindByNormalizedUserNameAsync(
                    LookupNormalizer.NormalizeName(adminUserName)
                );

                if (adminUser != null)
                {
                    (await _userManager.SetUserNameAsync(adminUser, input.Name)).CheckErrors();
                    adminUser.Name = input.Name;
                    (await _userManager.UpdateAsync(adminUser)).CheckErrors();
                    await CurrentUnitOfWork.SaveChangesAsync();

                    // Link current user to admin of new tenant
                    var linkUser = new IdentityLinkUserInfo((Guid)adminUser.Id, tenant.Id);
                    await _linkManager.LinkAsync(user, linkUser);

                }

                // Create role for new vendor
                //"admin" role
                const string adminRoleName = "admin";
                var adminRole = await _roleRepository.FindByNormalizedNameAsync(LookupNormalizer.NormalizeName(adminRoleName));
                try
                {
                    IdentityDbContext _ctx = await _dbContextProvider.GetDbContextAsync();
                    var sql = $"INSERT INTO public.\"AbpUserRoles\"(\n\t\"UserId\", \"RoleId\", \"TenantId\")\n\tVALUES ('{currentUser.Id}', '{adminRole.Id}', '{tenant.Id}');";
                    await _ctx.Database.ExecuteSqlRawAsync( sql);
                    //var newObj = new IdentityUserRoleExtension(currentUser.Id, adminRole.Id, tenant.Id);
                    //var role = newObj as IdentityUserRole;
                    //if (role == null)
                    //{
                    //}
                    //else
                    //{
                    //    await _userRoleRepository.InsertAsync(role);
                    //}
                }
                catch (Exception e)
                {
                    var str = e.ToString();
                    throw;
                }
                await _distributedEventBus.PublishAsync(
                    new TenantCreatedEto
                    {
                        Id = tenant.Id,
                        Name = tenant.Name,
                        Properties =
                        {
                                { "AdminEmail", input.AdminEmailAddress },
                                { "AdminPassword", input.AdminPassword }
                        }
                    });
                await _distributedEventBus.PublishAsync(
                    new EntityCreatedEto<TenantEto>(
                       new TenantEto
                       {
                           Id = tenant.Id,
                           Name = tenant.Name,                       
                       }
                    ));
                //await _distributedEventBus.PublishAsync(
                //       new VendorRoleEto
                //       {
                //           VendorId = tenant.Id,
                //           RoleId = adminRole.Id,
                //           UserId = currentUser.Id,
                //           RoleName = adminRole.Name,
                //       }
                //    );
            }
        }
        catch (Exception e)
        {
            throw new UserFriendlyException($"{e.ToString()}");
        }
        return ObjectMapper.Map<Tenant, TenantDto>(tenant);
        //return await TenantAppService.CreateAsync(input);
    }

    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleAsync()
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            //var currentUser = await _userRepository.GetAsync((Guid)CurrentUser.Id);
            var lstRole = await _userRepository.GetRolesAsync((Guid)CurrentUser.Id);
            return lstRole;
        }
    }

    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleByTenantAsync(Guid? id)
    {
        using (_dataFilter.Disable<IMultiTenant>())
        {
            //var currentUser = await _userRepository.GetAsync((Guid)CurrentUser.Id);
            //currentUser.Roles.RemoveAll(rol => rol.TenantId != id);

            var lstRole = await _userRepository.GetRolesAsync((Guid)CurrentUser.Id);
            if (id == null)
            {
                lstRole.RemoveAll(y => y.TenantId != null);
            }
            else
            {
                lstRole.RemoveAll(y => y.TenantId != id);
            }
            //var newUser = new IdentityUser(currentUser.Id, currentUser.UserName, currentUser.Email, id);
            //foreach (var rol in currentUser.Roles)
            //{
            //    newUser.AddRole(rol.RoleId);
            //}
            //newUser.SetConcurrencyStampIfNotNull();
            //var principal = await SignInManager.CreateUserPrincipalAsync(newUser);
            //var principal = await _abpUserClaimsPrincipalFactory.CreateAsync(newUser);
            //return SignIn(principal, OpenIdConnectServerDefaults.AuthenticationScheme);
            //SetClaimsDestinationsAsync(principal);

            ////var principal = await SignInManager.CreateUserPrincipalAsync(currentUser);
            //var str = OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
            //await SignInManager.SignInAsync(currentUser, isPersistent: false);
            return lstRole;
        }
    }

    public async Task<bool> TenantUserRoleAddAsync(Guid tenantId, TenantRoleCreateDto dto)
    {

        Volo.Abp.Identity.IdentityUser currentUser; // await _userRepository.GetAsync((Guid)CurrentUser.Id);
        using (CurrentTenant.Change(null))
        {
            currentUser = await _userRepository.GetAsync((Guid)CurrentUser.Id);
        }
        Guid userId = dto.UserId;
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var lstRole = await _userRepository.GetRolesAsync(currentUser.Id);            
            var linkuserinfo = new IdentityLinkUserInfo(userId, null);
            var linkUsers = await _linkManager.GetListAsync(linkuserinfo);
            if (linkUsers.Count > 0)
            {
                linkUsers.RemoveAll(x => (x.SourceUserId != userId) || x.TargetTenantId != tenantId);
                foreach (var lnk in linkUsers)
                {
                    var lstRoleTmp = await _userRepository.GetRolesAsync(lnk.TargetUserId);
                    if (lstRoleTmp.Count > 0)
                        lstRole.AddRange(lstRoleTmp);
                }
            }
            lstRole.RemoveAll(x => (x.TenantId != null && x.TenantId != tenantId));
            lstRole.RemoveAll(x => x.Name.ToLower() != "admin");
            if (lstRole.Count == 0)
            {
                throw new UserFriendlyException($"Role {dto.RoleName} not found");
            }
        }

        using (CurrentTenant.Change(tenantId, null))
        {
            var userRole = await _roleRepository.FindByNormalizedNameAsync(LookupNormalizer.NormalizeName(dto.RoleName));
            if (userRole == null)
            {
                throw new UserFriendlyException($"Role {dto.RoleName} not found");
            }
            try
            {
                if (userRole.TenantId != tenantId)
                {
                    throw new UserFriendlyException($"Role {dto.RoleName} is invalid");
                }
                var _ctx = await _dbContextProvider.GetDbContextAsync();
                var sql = $"INSERT INTO public.\"AbpUserRoles\"(\n\t\"UserId\", \"RoleId\", \"TenantId\")\n\tVALUES ('{userId}', '{userRole.Id}', '{tenantId}');";
                await _ctx.Database.ExecuteSqlRawAsync(sql);
                //var newObj = new IdentityUserRoleExtension(currentUser.Id, adminRole.Id, tenant.Id);
                //var role = newObj as IdentityUserRole;
                //if (role == null)
                //{
                //}
                //else
                //{
                //    await _userRoleRepository.InsertAsync(role);
                //}
                //await _distributedEventBus.PublishAsync(
                //       new VendorRoleEto
                //       {
                //           VendorId = vendorId,
                //           RoleId = userRole.Id,
                //           UserId = userId,
                //           RoleName = dto.name,
                //       }
                //    );
            }
            catch (Exception e)
            {
                var str = e.ToString();
                throw;
            }
        }
        await Task.CompletedTask;
        return true;
    }

    public async Task<bool> TenantUserRoleRemoveAsync(Guid tenantId, Guid userId)
    {
        Volo.Abp.Identity.IdentityUser currentUser;
        using (CurrentTenant.Change(null))
        {
            currentUser = await _userRepository.GetAsync((Guid)CurrentUser.Id);
        }
        if (userId == currentUser.Id)
        {
            throw new UserFriendlyException($"Cannot remove your self");
        }
        using (_dataFilter.Disable<IMultiTenant>())
        {
            var lstRole = await _userRepository.GetRolesAsync(currentUser.Id);
            var linkuserinfo = new IdentityLinkUserInfo(userId, null);
            var linkUsers = await _linkManager.GetListAsync(linkuserinfo);
            if (linkUsers.Count > 0)
            {
                linkUsers.RemoveAll(x => (x.SourceUserId != userId) || x.TargetTenantId != tenantId);
                foreach (var lnk in linkUsers)
                {
                    var lstRoleTmp = await _userRepository.GetRolesAsync(lnk.TargetUserId);
                    if (lstRoleTmp.Count > 0)
                        lstRole.AddRange(lstRoleTmp);
                }
            }
            lstRole.RemoveAll(x => (x.TenantId != null && x.TenantId != tenantId));
            lstRole.RemoveAll(x => x.Name.ToLower() != "admin");
            if (lstRole.Count == 0)
            {
                throw new UserFriendlyException($"No Access");
            }
            IdentityDbContext _ctx = await _dbContextProvider.GetDbContextAsync();
            var sql = $"DELETE FROM public.\"AbpUserRoles\"(\n\t\"UserId\", \"RoleId\", \"TenantId\")\n\t WHERE \"UserId\"='{userId}' AND \"TenantId\" = '{tenantId}');";
            await _ctx.Database.ExecuteSqlRawAsync(sql);
        }
        return true;
    }

    //[HttpGet]
    //[Route("vendor-link")]
    //public async Task<string> GetVendorJwtAsync(Guid id)
    //{
    //    using (CurrentTenant.Change(null))
    //    {
    //        var linkUser = new IdentityLinkUserInfo((Guid)CurrentUser.Id, null);
    //        var lst = await _linkManager.GetListAsync(linkUser, true);
    //        //var user = await _userManager.GetByIdAsync((Guid)CurrentUser.Id);
    //        //var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "");
    //        if (lst.Count == 0)
    //        {

    //        }
    //    }
    //    // Create a new ClaimsPrincipal containing the claims that
    //    // will be used to create an id_token, a token or a code.
    //    //var principal = await SignInManager.CreateUserPrincipalAsync(user);

    //    //principal.SetScopes(request.GetScopes());
    //    //principal.SetResources(await GetResourcesAsync(request.GetScopes()));

    //    //await SetClaimsDestinationsAsync(principal);

    //    //await IdentitySecurityLogManager.SaveAsync(
    //    //    new IdentitySecurityLogContext
    //    //    {
    //    //        Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
    //    //        Action = OpenIddictSecurityLogActionConsts.LoginSucceeded,
    //    //        UserName = request.Username,
    //    //        ClientId = request.ClientId
    //    //    }
    //    //);

    //    //return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    //    return "";
    //    //throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.GetDefaultConnectionStringAsync(id);
    //}
    //[HttpGet]
    //[Route("claims")]
    //public JsonResult Get()
    //{
    //    return Json(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
    //}

    //[HttpGet]
    //[Route("access_token")]
    //public async Task<string> Token(Guid tenant)
    //{
    //    var user = await _userRepository.FindAsync((Guid)CurrentUser.Id);

    //    var token = await _userManager.GenerateUserTokenAsync(user, "PasswordlessLoginProvider", "passwordless-auth");

    //    return token;
    //    //return Json(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
    //}



    //[HttpGet]
    //[Route("default-connection")]
    //public async Task<string> GetDefaultConnectionStringAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.GetDefaultConnectionStringAsync(id);
    //}

    //[HttpGet]
    //[Route("update-connection")]
    //public async Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);
    //}
    //[HttpDelete]
    //[Route("delete-connection")]
    //public async Task DeleteDefaultConnectionStringAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.DeleteDefaultConnectionStringAsync(id);
    //}

    //[HttpPut]
    //[Route("{id}")]
    //public async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.UpdateAsync(id, input);
    //}

    //[HttpDelete]
    //[Route("{id}")]
    //public async Task DeleteAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.DeleteAsync(id);
    //}

    //[HttpPut]
    //[Route("{id}")]
    //public async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    //{
    //    return await TenantAppService.UpdateAsync(id, input);
    //}

    //[HttpDelete]
    //[Route("{id}")]
    //public async Task DeleteAsync(Guid id)
    //{
    //    await TenantAppService.DeleteAsync(id);
    //}

}


    //[HttpGet]
    //[Route("vendor-link")]
    //public async Task<string> GetVendorJwtAsync(Guid id)
    //{
    //    using (CurrentTenant.Change(null))
    //    {
    //        var linkUser = new IdentityLinkUserInfo((Guid)CurrentUser.Id, null);
    //        var lst = await _linkManager.GetListAsync(linkUser, true);
    //        //var user = await _userManager.GetByIdAsync((Guid)CurrentUser.Id);
    //        //var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "");
    //        if (lst.Count == 0)
    //        {

    //        }
    //    }
    //    // Create a new ClaimsPrincipal containing the claims that
    //    // will be used to create an id_token, a token or a code.
    //    //var principal = await SignInManager.CreateUserPrincipalAsync(user);

    //    //principal.SetScopes(request.GetScopes());
    //    //principal.SetResources(await GetResourcesAsync(request.GetScopes()));

    //    //await SetClaimsDestinationsAsync(principal);

    //    //await IdentitySecurityLogManager.SaveAsync(
    //    //    new IdentitySecurityLogContext
    //    //    {
    //    //        Identity = OpenIddictSecurityLogIdentityConsts.OpenIddict,
    //    //        Action = OpenIddictSecurityLogActionConsts.LoginSucceeded,
    //    //        UserName = request.Username,
    //    //        ClientId = request.ClientId
    //    //    }
    //    //);

    //    //return SignIn(principal, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

    //    return "";
    //    //throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.GetDefaultConnectionStringAsync(id);
    //}
    //[HttpGet]
    //[Route("claims")]
    //public JsonResult Get()
    //{
    //    return Json(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
    //}

    //[HttpGet]
    //[Route("access_token")]
    //public async Task<string> Token(Guid tenant)
    //{
    //    var user = await _userRepository.FindAsync((Guid)CurrentUser.Id);

    //    var token = await _userManager.GenerateUserTokenAsync(user, "PasswordlessLoginProvider", "passwordless-auth");

    //    return token;
    //    //return Json(User.Claims.Select(x => new { Type = x.Type, Value = x.Value }));
    //}



    //[HttpGet]
    //[Route("default-connection")]
    //public async Task<string> GetDefaultConnectionStringAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.GetDefaultConnectionStringAsync(id);
    //}

    //[HttpGet]
    //[Route("update-connection")]
    //public async Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);
    //}
    //[HttpDelete]
    //[Route("delete-connection")]
    //public async Task DeleteDefaultConnectionStringAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.DeleteDefaultConnectionStringAsync(id);
    //}

    //[HttpPut]
    //[Route("{id}")]
    //public async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.UpdateAsync(id, input);
    //}

    //[HttpDelete]
    //[Route("{id}")]
    //public async Task DeleteAsync(Guid id)
    //{
    //    await Task.CompletedTask;
    //    throw new UserFriendlyException($"Not support");
    //    //return TenantAppService.DeleteAsync(id);
    //}

    //[HttpPut]
    //[Route("{id}")]
    //public async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input)
    //{
    //    return await TenantAppService.UpdateAsync(id, input);
    //}

    //[HttpDelete]
    //[Route("{id}")]
    //public async Task DeleteAsync(Guid id)
    //{
    //    await TenantAppService.DeleteAsync(id);
    //}


/*
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
*/