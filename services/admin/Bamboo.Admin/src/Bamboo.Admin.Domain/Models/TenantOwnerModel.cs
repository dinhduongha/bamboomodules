using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.TenantManagement;

namespace Bamboo.Admin;

[Table("AbpTenants")]
public class TenantOwner: Tenant
{
    public Guid? OwnerId { get; set; }
    public Guid? ParentId { get; set; }
    public TenantOwner()
    {

    }
}


