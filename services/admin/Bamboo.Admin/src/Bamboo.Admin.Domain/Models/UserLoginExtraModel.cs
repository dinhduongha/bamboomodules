using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Bamboo.Admin;

[Table("AbpUserLogins")]
public class UserLoginExtra: IdentityUserLogin, IHasExtraProperties
{
    public virtual ExtraPropertyDictionary ExtraProperties { get; set; }
    public virtual string? ProviderName { get; set; }
    public UserLoginExtra()
    {
        ExtraProperties = new ExtraPropertyDictionary();
        this.SetDefaultsForExtraProperties();
    }
}