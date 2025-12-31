using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;


using Bamboo.Admin.Application.Dtos;
using Bamboo.Admin.Application.Services;


namespace Bamboo.Admin.Controllers;

[Authorize(Roles = "superadmin,admin")]
[RemoteService]
[Area("admin")]
[Route("api/tenant-members/members")]
public class TenantMemberController : AbpControllerBase
{
    private readonly ITenantMemberAppService _tenantMemberAppService;

    public TenantMemberController(ITenantMemberAppService tenantMemberAppService)
    {
        _tenantMemberAppService = tenantMemberAppService;
    }

    [HttpGet]
    public Task<PagedResultDto<TenantMemberDto>> GetListAsync(GetTenantMembersInput input) => _tenantMemberAppService.GetListAsync(input);

    [HttpGet("{id}")]
    public Task<TenantMemberDto> GetAsync(Guid id) => _tenantMemberAppService.GetAsync(id);

    [HttpPost]
    public Task<TenantMemberDto> CreateAsync(CreateTenantMemberDto input) => _tenantMemberAppService.CreateAsync(input);

    [HttpPut("{id}")]
    public Task<TenantMemberDto> UpdateAsync(Guid id, UpdateTenantMemberDto input) => _tenantMemberAppService.UpdateAsync(id, input);

    [HttpDelete("{id}")]
    public Task DeleteAsync(Guid id) => _tenantMemberAppService.DeleteAsync(id);


    [HttpPost("invite")]
    public Task<TenantMemberDto> InviteAsync(InviteMemberDto input) => _tenantMemberAppService.InviteAsync(input);

}