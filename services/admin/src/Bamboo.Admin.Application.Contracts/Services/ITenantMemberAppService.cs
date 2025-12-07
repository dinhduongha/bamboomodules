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
        GetTenantMemberListInput,
        CreateTenantMemberDto,
        UpdateTenantMemberDto>
{
    Task<TenantMemberDto> InviteAsync(InviteMemberDto input); // Đổi từ CreateAsync
    Task<ListResultDto<TenantMemberDto>> GetMyInvitationsAsync();
    Task AcceptInvitationAsync(Guid invitationId);
    Task RejectInvitationAsync(Guid invitationId);
}