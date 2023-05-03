using System;
using System.Threading.Tasks;
using System.Numerics;
using System.Net.Mail;
using System.Linq;
using System.Net.Http;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

using Volo.Abp;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;
using Volo.Abp.Users;
using Volo.Abp.Data;
using Volo.Abp.Linq;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Application.Services;

[Route("api/vendor/")]
[Authorize]
public class VendorController2 : AbpControllerBase
{
    //private readonly ICurrentUser _currentUser;
    //private readonly ITenantManager _tenantManager;
    //private readonly IdentityUserManager _userManager;
    //protected IDataSeeder _dataSeeder { get; }

    //private readonly ITenantRepository _tenantRepository;
    //private readonly IIdentityUserRepository _userRepository;

    //private readonly IRepository<Tenant, Guid> _tenantRepos;
    ////private readonly IRepository<CurrentUser, Guid> _userRepos;
    //IHttpClientFactory _httpClientFactory;
    ////ILinkAccountManager _linkManager;
    //public VendorController(ICurrentUser currentUser,
    //        ITenantManager tenantManager,
    //        ITenantRepository tenantRepository,
    //        IdentityUserManager userManager,
    //        IIdentityUserRepository userRepository,
    //        IRepository<Tenant, Guid> tenantRepos,
    //        IHttpClientFactory httpFactory,
    //        //ILinkAccountManager linkManager,
    //        IDataSeeder dataSeeder)
    //    :base()
    //{
    //    _tenantManager = tenantManager;
    //    _currentUser = currentUser;
    //    _userManager = userManager;
    //    _tenantRepository = tenantRepository;
    //    _userRepository = userRepository;
    //    _dataSeeder = dataSeeder;
    //    _tenantRepos = tenantRepos;
    //    _httpClientFactory = httpFactory;
    //    //_linkManager = linkManager;
    //}

    //[HttpPost]
    //[Route("create")]
    //public async Task<TenantDto> CreateVendor(TenantCreateDto input)
    //{
    //    if (CurrentUser.TenantId != null)
    //    {
    //        throw new Exception("Only host user can create tenant");
    //    }
    //    var count = await _tenantRepos.CountAsync(    x => x.CreatorId == CurrentUser.Id);
    //    if (count > 3)
    //    {
    //        throw new Exception($"Too many tenant created");
    //    }
    //    var tenant = await _tenantRepository.FindByNameAsync(input.Name);
    //    if (tenant == null)
    //    {
    //        tenant = await _tenantManager.CreateAsync(input.Name);
    //        tenant.CreatorId = CurrentUser.Id;
    //        tenant = await _tenantRepository.InsertAsync(tenant);
    //        await CurrentUnitOfWork.SaveChangesAsync();

    //        using (CurrentTenant.Change(tenant.Id, tenant.Name))
    //        {
    //            await _dataSeeder.SeedAsync(new DataSeedContext(tenant.Id)
    //                .WithProperty(IdentityDataSeedContributor.AdminEmailPropertyName, $"{input.Name}@Bamboo.io")
    //                .WithProperty(IdentityDataSeedContributor.AdminPasswordPropertyName, $"{input.AdminPassword}")
    //                );
    //        }
    //    }
    //    await Task.CompletedTask;
    //    return ObjectMapper.Map<Tenant, TenantDto>(tenant);
    //}

}
