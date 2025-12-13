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

[Authorize]
[RemoteService]
[Route("api/tenant-members/tenant-workspaces")]
public class TenantMemberWorkspaceController : AbpControllerBase
{
    private readonly ITenantMemberAppService _tenantMemberAppService;

    public TenantMemberWorkspaceController(ITenantMemberAppService tenantMemberAppService)
    {
        _tenantMemberAppService = tenantMemberAppService;
    }

    // [HttpGet]
    // public Task<PagedResultDto<TenantMemberDto>> GetListAsync(GetTenantMembersInput input) => _tenantMemberAppService.GetListAsync(input);

    // [HttpGet("{id}")]
    // public Task<TenantMemberDto> GetAsync(Guid id) => _tenantMemberAppService.GetAsync(id);

    // [HttpPost]
    // public Task<TenantMemberDto> CreateAsync(CreateTenantMemberDto input) => _tenantMemberAppService.CreateAsync(input);

    // [HttpPut("{id}")]
    // public Task<TenantMemberDto> UpdateAsync(Guid id, UpdateTenantMemberDto input) => _tenantMemberAppService.UpdateAsync(id, input);

    // [HttpDelete("{id}")]
    // public Task DeleteAsync(Guid id) => _tenantMemberAppService.DeleteAsync(id);


    // [HttpPost("invite")]
    // public Task<TenantMemberDto> InviteAsync(InviteMemberDto input) => _tenantMemberAppService.InviteAsync(input);

    [HttpGet]
    public Task<PagedResultDto<TenantMemberDto>> GetMyInvitationsAsync() => _tenantMemberAppService.GetMyInvitationsAsync();

    [HttpPost("accept-invitation/{invitationId}")]
    public Task AcceptInvitationAsync(Guid invitationId) => _tenantMemberAppService.AcceptInvitationAsync(invitationId);

    [HttpPost("reject-invitation/{invitationId}")]
    public Task RejectInvitationAsync(Guid invitationId) => _tenantMemberAppService.RejectInvitationAsync(invitationId);

    // [HttpGet("create-modal")] public IActionResult CreateModal() => PartialView("~/Pages/Members/CreateModal.cshtml");
    // [HttpGet("edit-modal")] public async Task<IActionResult> EditModal(Guid id) => PartialView("~/Pages/Members/EditModal.cshtml", await _tenantMemberAppService.GetAsync(id));

    //[HttpGet("create-modal")] public IActionResult CreateModal() => PartialView("~/Pages/Members/CreateModal.cshtml");
    //[HttpGet("edit-modal")] public async Task<IActionResult> EditModal(Guid id) => PartialView("~/Pages/Members/EditModal.cshtml", await _tenantMemberAppService.GetAsync(id));
}