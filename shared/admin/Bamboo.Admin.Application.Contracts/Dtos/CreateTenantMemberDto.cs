using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Bamboo.Admin.Domain.Shared.Enums;

namespace Bamboo.Admin.Application.Dtos;

public class CreateTenantMemberDto
{
    [Required]
    public Guid UserId { get; set; }
    public Guid? TenantId { get; set; }
    public string? Role { get; set; }
    public List<string>? Roles { get; set; } = new();
    public TenantMemberStatus? Status { get; set; } = TenantMemberStatus.Active;
    public InvitationStatus? InviteStatus { get; protected set; } = InvitationStatus.Pending;
    public bool? IsOwner { get; set; }
    public bool? IsActive { get; set; }
    public string? Description { get; set; }
}
