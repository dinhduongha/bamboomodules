using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
namespace Bamboo.AdminExtensions.Dtos;

public class TenantRoleCreateDto
{
    public string RoleName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}

public class TenantMigrateDto
{
    public Guid? Uuid { get; set; }
    public long? Id { get; set; }
    public string? Name { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(256)]
    public string? AdminEmail { get; set; } = string.Empty;

    [DisableAuditing]
    [MaxLength(128)]
    public string? Password { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
}