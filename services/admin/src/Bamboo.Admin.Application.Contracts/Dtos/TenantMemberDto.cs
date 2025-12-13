using System;
using System.Collections.Generic;
using System.Text.Json;
using Volo.Abp.Application.Dtos;

using Bamboo.Admin.Domain.Shared.Enums;

namespace Bamboo.Admin.Application.Dtos;

public class TenantMemberDto : FullAuditedEntityDto<Guid>
{
    public Guid? TenantId { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public string? TenantName { get; set; }
    public string? Role { get; set; }
    public List<string>? Roles { get; set; } = [];
    public TenantMemberStatus Status { get; set; }
    public InvitationStatus InviteStatus { get; protected set; } = InvitationStatus.Pending;
    public bool? IsActive { get; set; }
    public bool? IsAccepted { get; set; }
    public bool? IsRejected { get; set; }
    public bool? IsLeaved { get; set; }
    public DateTimeOffset? InvitedAt { get; set; }
    public DateTimeOffset? AcceptedAt { get; set; }
    public DateTimeOffset? RejectedAt { get; set; }
    public DateTimeOffset? LeavedAt { get; set; }
    public DateTimeOffset? SuspendedAt { get; set; }
    public bool IsOwner { get; set; }
    public JsonElement? Info { get; set; }
}

public class MemberDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid? TenantId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string TenantName { get; set; }
    public string Role { get; set; }
    public List<string> Roles { get; set; } = new();
    public TenantMemberStatus Status { get; set; }
    public InvitationStatus InviteStatus { get; set; }
    public DateTimeOffset? JoinedDate { get; set; }
}