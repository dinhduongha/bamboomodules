using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
using System.Net.Http;
using System.Xml.Linq;

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
//[Area(IntegrateRemoteServiceConsts.ModuleName)]
//[RemoteService(Name = IntegrateRemoteServiceConsts.RemoteServiceName)]
[Route("api/admin/tenant-management/")]
[Produces("application/json")]
//[Authorize]
//[AllowAnonymous]
public class TenantExtraController : AbpController
{
    private readonly TenantService _tenantService;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;

    public TenantExtraController(TenantService tenantService,
                            IConfiguration configuration,
                            ILookupNormalizer lookupNormalizer,
                            IHttpClientFactory httpClientFactory)
        : base()
    {
        _configuration = configuration;
        _httpClientFactory = httpClientFactory;
        _tenantService = tenantService;

    }
    [HttpGet]
    [Route("{id}")]
    public async Task<TenantDto> GetAsync(Guid id)
    {
        return await _tenantService.GetAsync(id);
    }

    [HttpGet]
    public async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        return await _tenantService.GetListAsync(input);
    }

    [HttpPost]
    public async Task<TenantDto> CreateAsync(string name)
    {
        return await _tenantService.CreateAsync(name);
    }

    [HttpGet]
    [Route("roles")]
    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleAsync()
    {
        return await _tenantService.GetRoleAsync();
    }

    [HttpGet]
    [Route("roles/{tenant}")]
    public async Task<List<Volo.Abp.Identity.IdentityRole>> GetRoleByTenantAsync(Guid? tenant)
    {
        return await _tenantService.GetRoleByTenantAsync(tenant);
    }

    [HttpPost]
    [Route("roles-add/{tenant}")]
    public async Task<bool> VendorRoleAddAsync(Guid tenant, TenantRoleCreateDto dto)
    {
        return await _tenantService.TenantUserRoleAddAsync(tenant, dto);
    }

    [HttpDelete]
    [Route("roles-remove/{tenant}/{user}")]
    public async Task<bool> VendorRoleRemoveAsync(Guid tenant, Guid user)
    {
        return await _tenantService.TenantUserRoleRemoveAsync(tenant, user);
    }

}