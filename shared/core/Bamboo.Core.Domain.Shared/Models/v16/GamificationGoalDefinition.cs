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

[Table("gamification_goal_definition")]
public partial class GamificationGoalDefinition: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("field_date_id")]
    public Guid? FieldDateId { get; set; }

    [Column("batch_distinctive_field")]
    public Guid? BatchDistinctiveField { get; set; }

    [Column("action_id")]
    public Guid? ActionId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("computation_mode")]
    public string? ComputationMode { get; set; }

    [Column("display_mode")]
    public string? DisplayMode { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("batch_user_expression")]
    public string? BatchUserExpression { get; set; }

    [Column("condition")]
    public string? Condition { get; set; }

    [Column("res_id_field")]
    public string? ResIdField { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("suffix", TypeName = "jsonb")]
    public string? Suffix { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("compute_code")]
    public string? ComputeCode { get; set; }

    [Column("monetary")]
    public bool? Monetary { get; set; }

    [Column("batch_mode")]
    public bool? BatchMode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("ActionId")]
    // [InverseProperty("GamificationGoalDefinition")] //Many2one
    public virtual IrActWindow? Action { get; set; }

    // [Many2one]
    [ForeignKey("BatchDistinctiveField")]
    // [InverseProperty("GamificationGoalDefinitionBatchDistinctiveFieldNavigation")] //Many2one
    public virtual IrModelFields? BatchDistinctiveFieldNavigation { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("GamificationGoalDefinitionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FieldId")]
    // [InverseProperty("GamificationGoalDefinitionField")] //Many2one
    public virtual IrModelFields? Field { get; set; }

    // [Many2one]
    [ForeignKey("FieldDateId")]
    // [InverseProperty("GamificationGoalDefinitionFieldDate")] //Many2one
    public virtual IrModelFields? FieldDate { get; set; }

    // [One2many]
    [ForeignKey("DefinitionId")]
    [InverseProperty("Definition")]
    public virtual ICollection<GamificationChallengeLine> GamificationChallengeLine { get; set; }

    // [One2many]
    [ForeignKey("DefinitionId")]
    [InverseProperty("Definition")]
    public virtual ICollection<GamificationGoal> GamificationGoal { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("GamificationGoalDefinition")] //Many2one
    public virtual IrModel? Model { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("GamificationGoalDefinitionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("GamificationGoalDefinitionId")]
    // [InverseProperty("GamificationGoalDefinition")]
    // public virtual ICollection<GamificationBadge> GamificationBadge { get; set; }
}
