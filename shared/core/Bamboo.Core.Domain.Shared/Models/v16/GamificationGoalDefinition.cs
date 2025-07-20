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
public partial class GamificationGoalDefinition: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ActionId")]
    //[InverseProperty("GamificationGoalDefinitions")]
    [NotMapped]
    public virtual IrActWindow? Action { get; set; }

    [ForeignKey("BatchDistinctiveField")]
    //[InverseProperty("GamificationGoalDefinitionBatchDistinctiveFieldNavigations")]
    [NotMapped]
    public virtual IrModelField? BatchDistinctiveFieldNavigation { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("GamificationGoalDefinitionCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("GamificationGoalDefinitionFields")]
    [NotMapped]
    public virtual IrModelField? Field { get; set; }

    [ForeignKey("FieldDateId")]
    //[InverseProperty("GamificationGoalDefinitionFieldDates")]
    [NotMapped]
    public virtual IrModelField? FieldDate { get; set; }

    //[InverseProperty("Definition")]
    [NotMapped]
    public virtual ICollection<GamificationChallengeLine> GamificationChallengeLines { get; set; } = new List<GamificationChallengeLine>();

    //[InverseProperty("Definition")]
    [NotMapped]
    public virtual ICollection<GamificationGoal> GamificationGoals { get; set; } = new List<GamificationGoal>();

    [ForeignKey("ModelId")]
    //[InverseProperty("GamificationGoalDefinitions")]
    [NotMapped]
    public virtual IrModel? Model { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("GamificationGoalDefinitionWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("GamificationGoalDefinitionId")]
    //[InverseProperty("GamificationGoalDefinitions")]
    [NotMapped]
    public virtual ICollection<GamificationBadge> GamificationBadges { get; set; } = new List<GamificationBadge>();
}
