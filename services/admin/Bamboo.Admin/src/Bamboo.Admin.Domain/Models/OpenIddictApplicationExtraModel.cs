using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.OpenIddict.Applications;

namespace Bamboo.Admin;

[Table("OpenIddictApplications")]
public class OpenIddictApplicationExtra : OpenIddictApplication 
{
    public OpenIddictApplicationExtra(Guid id)
    : base(id)
    {
    }
    public virtual Guid? TenantId { get; set; }
}