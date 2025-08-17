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

[Table("ir_model_access")]
//[Index("GroupId", Name = "ir_model_access__group_id_index")]
//[Index("ModelId", Name = "ir_model_access__model_id_index")]
//[Index("Name", Name = "ir_model_access__name_index")]
public partial class IrModelAccess: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    
    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("perm_read")]
    public bool? PermRead { get; set; }

    [Column("perm_write")]
    public bool? PermWrite { get; set; }

    [Column("perm_create")]
    public bool? PermCreate { get; set; }

    [Column("perm_unlink")]
    public bool? PermUnlink { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModelAccessCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("GroupId")]
    // [InverseProperty("IrModelAccess")] //Many2one
    public virtual ResGroups? Group { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("IrModelAccess")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModelAccessWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
