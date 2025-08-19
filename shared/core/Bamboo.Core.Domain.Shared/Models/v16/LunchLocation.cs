using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("lunch_location")]
public partial class LunchLocation: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("address")]
    public string? Address { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LunchLocation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LunchLocationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("LunchLocationId")]
    [InverseProperty("LunchLocation")]
    public virtual ICollection<LunchOrder> LunchOrder { get; set; }

    // [One2many]
    [ForeignKey("LastLunchLocationId")]
    [InverseProperty("LastLunchLocation")]
    public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LunchLocationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LunchLocationId")]
    // [InverseProperty("LunchLocation")]
    public virtual ICollection<LunchAlert> LunchAlert { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("LunchLocationId")]
    // [InverseProperty("LunchLocation")]
    public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }
}
