using System;
using System.IO;

using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

using Bamboo.Admin.Application.Dtos;

namespace Bamboo.Admin.Application.Services;

public interface ITenantMemberAppService :
    ICrudAppService<
        TenantMemberDto,
        Guid,
        GetTenantMembersInput,
        CreateTenantMemberDto,
        UpdateTenantMemberDto>
{
    Task<TenantMemberDto> InviteAsync(InviteMemberDto input); // Đổi từ CreateAsync
    Task<PagedResultDto<TenantMemberDto>> GetMyInvitationsAsync();
    Task AcceptInvitationAsync(Guid invitationId);
    Task RejectInvitationAsync(Guid invitationId);
}