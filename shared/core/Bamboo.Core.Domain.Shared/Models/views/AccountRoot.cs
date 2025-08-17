using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class AccountRoot: Entity<Guid>, IMultiTenant
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
}
