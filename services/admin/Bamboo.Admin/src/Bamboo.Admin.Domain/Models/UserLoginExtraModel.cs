using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Bamboo.Admin;

[Table("AbpUserLogins")]
public class UserLoginExtraModel: Entity<Guid>, IHasExtraProperties
{
    public virtual string? ProviderName { get; protected set; }
    public virtual ExtraPropertyDictionary ExtraProperties { get; protected set; }
    public UserLoginExtraModel()
    {
        ExtraProperties = new ExtraPropertyDictionary();
    }
}