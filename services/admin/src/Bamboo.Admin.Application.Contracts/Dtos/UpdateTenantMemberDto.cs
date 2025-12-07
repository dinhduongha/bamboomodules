using System;
using System.Collections.Generic;

using Bamboo.Admin.Domain.Shared.Enums;

namespace Bamboo.Admin.Application.Dtos;

public class UpdateTenantMemberDto
{
    public string? Role { get; set; }
    public List<string>? Roles { get; set; }
    public TenantMemberStatus? Status { get; set; }
    public bool? IsOwner { get; set; }
    public bool? IsActive { get; set; }
}
