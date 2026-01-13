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
[Route("api/tenant-members/workspaces")]
public class TenantMemberWorkspaceController : AbpControllerBase
{
    private readonly ITenantMemberAppService _tenantMemberAppService;

    public TenantMemberWorkspaceController(ITenantMemberAppService tenantMemberAppService)
    {
        _tenantMemberAppService = tenantMemberAppService;
    }


    [HttpGet]
    public Task<PagedResultDto<TenantMemberDto>> GetMyWorkspacesAsync() => _tenantMemberAppService.GetMyWorkspacesAsync();

    [HttpPost("accept-invitation/{invitationId}")]
    public Task AcceptInvitationAsync(Guid invitationId) => _tenantMemberAppService.AcceptInvitationAsync(invitationId);

    [HttpPost("reject-invitation/{invitationId}")]
    public Task RejectInvitationAsync(Guid invitationId) => _tenantMemberAppService.RejectInvitationAsync(invitationId);

}