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

[Table("ir_rule")]
//[Index("ModelId", Name = "ir_rule__model_id_index")]
//[Index("Name", Name = "ir_rule__name_index")]
public partial class IrRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
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

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("domain_force")]
    public string? DomainForce { get; set; }

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

    [Column("global")]
    public bool? Global { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("IrRule")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("RuleGroupId")] //Many2many
    // [InverseProperty("RuleGroup")] //Many2many
    public virtual ICollection<ResGroups> Groups { get; set; }
}
