using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
namespace Bamboo.AdminExtensions.Dtos;

public class TenantRoleCreateDto
{
    public string RoleName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}

public class TenantMigrateDto
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public long Id { get; set; }
}