using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http;

using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

using IdentityUser = Volo.Abp.Identity.IdentityUser;

using Bamboo.AdminExtensions.Dtos;
using Bamboo.AdminExtensions;
using Bamboo.Admin.HttpApi.Filters;

//[Area(IntegrateRemoteServiceConsts.ModuleName)]
//[RemoteService(Name = IntegrateRemoteServiceConsts.RemoteServiceName)]
[Route("api/host-admin/")]
[Produces("application/json")]
[Authorize(Roles = "superadmin,admin")]
[HostOnly]
public class HostAdminController : AbpController
{
    protected readonly AdminResetPasswordAppService _adminResetPasswordService;
    protected readonly TenantService _tenantService;
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly IConfiguration _configuration;

    public HostAdminController(TenantService tenantService,
                            AdminResetPasswordAppService adminResetPasswordService,
                            IConfiguration configuration,
                            ILookupNormalizer lookupNormalizer,
                            IHttpClientFactory httpClientFactory)
        : base()
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _tenantService = tenantService;
        _adminResetPasswordService = adminResetPasswordService;

    }

    // [HttpGet]
    // [Route("{id}")]
    // public async Task<TenantDto> GetAsync(Guid id)
    // {
    //     return await _tenantService.GetAsync(id);
    // }

    // [HttpGet]
    // public async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    // {
    //     return await _tenantService.GetListAsync(input);
    // }

    [NonAction]
    [HttpPost]
    public async Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        return await _tenantService.CreateAsync(input);
    }

    [HttpPost]
    [Route("tenants/migrate")]
    public async Task<TenantDto> CreateWithIdAsync(TenantMigrateDto data)
    {
        return await _tenantService.MigrateAsync(data);
    }
    [NonAction]
    [HttpGet]
    [Route("roles")]
    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleAsync()
    {
        return await _tenantService.GetRoleAsync();
    }

    [NonAction]
    [HttpGet]
    [Route("roles/{tenant}")]
    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleByTenantAsync(Guid? tenant)
    {
        return await _tenantService.GetRoleByTenantAsync(tenant);
    }

    [NonAction]
    [HttpPost]
    [Route("user-roles-add/{tenant}")]
    public async Task<bool> TenantRoleAddAsync(Guid tenant, TenantRoleCreateDto dto)
    {
        return await _tenantService.TenantUserRoleAddAsync(tenant, dto);
    }

    [NonAction]
    [HttpDelete]
    [Route("user-roles-remove/{tenant}/{user}")]
    public async Task<bool> TenantRoleRemoveAsync(Guid tenant, Guid user)
    {
        return await _tenantService.TenantUserRoleRemoveAsync(tenant, user);
    }

    [HttpPost]
    [Route("users/reset-user-password")]
    public async Task AdminResetPassword([FromBody] ResetUserPasswordDto input)
    {
        await _adminResetPasswordService.AdminResetPasswordAsync(input);
    }
}