using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;
namespace Bamboo.AdminExtensions.Dtos;

public class TenantRoleCreateDto
{
    public string RoleName { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}
