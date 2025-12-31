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
using static System.Runtime.InteropServices.JavaScript.JSType;
//[Area(IntegrateRemoteServiceConsts.ModuleName)]
//[RemoteService(Name = IntegrateRemoteServiceConsts.RemoteServiceName)]
[Route("api/host-user/")]
[Produces("application/json")]
//[Authorize(Roles="members")]
//[AllowAnonymous]
public class HostUserController : AbpController
{
    protected readonly AdminResetPasswordAppService _adminResetPasswordService;
    protected readonly TenantService _tenantService;
    protected readonly IHttpClientFactory _httpClientFactory;
    protected readonly IConfiguration _configuration;

    public HostUserController(TenantService tenantService,
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

    [HttpGet]
    [Route("tenants/{id}")]
    public async Task<TenantDto> GetAsync(Guid id)
    {
        return await _tenantService.GetAsync(id);
    }

    [HttpGet]
    [Route("tenants")]
    public async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)
    {
        return await _tenantService.GetListAsync(input);
    }

    [HttpPost]
    [Route("tenants/register")]
    public async Task<TenantDto> CreateAsync(TenantCreateDto input)
    {
        return await _tenantService.CreateAsync(input);
    }
}