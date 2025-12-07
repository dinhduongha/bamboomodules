using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Bamboo.Admin;

[Table("AbpUserLogins")]
public class UserLoginExtra : IdentityUserLogin
{
    public virtual bool? IsActive { get; set; } = true;
    public virtual string? ProviderName { get; protected set; }
}