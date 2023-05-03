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
//[Index("ModelId", Name = "ir_rule_model_id_index")]
//[Index("Name", Name = "ir_rule_name_index")]
public partial class IrRule: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ModelId")]
    //[InverseProperty("IrRules")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("RuleGroupId")]
    //[InverseProperty("RuleGroups")]
    [NotMapped]
    public virtual ICollection<ResGroup> Groups { get; } = new List<ResGroup>();
}
