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

[Table("gamification_goal")]
//[Index("ChallengeId", Name = "gamification_goal__challenge_id_index")]
public partial class GamificationGoal: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("definition_id")]
    public Guid? DefinitionId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("line_id")]
    public Guid? LineId { get; set; }

    [Column("challenge_id")]
    public Guid? ChallengeId { get; set; }

    [Column("remind_update_delay")]
    public long? RemindUpdateDelay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("start_date")]
    public DateTime? StartDate { get; set; }

    [Column("end_date")]
    public DateTime? EndDate { get; set; }

    [Column("last_update")]
    public DateTime? LastUpdate { get; set; }

    [Column("to_update")]
    public bool? ToUpdate { get; set; }

    [Column("closed")]
    public bool? Closed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("target_goal")]
    public double? TargetGoal { get; set; }

    [Column("current")]
    public double? Current { get; set; }

    // [Many2one]
    [ForeignKey("ChallengeId")]
    public virtual GamificationChallenge? Challenge { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DefinitionId")]
    public virtual GamificationGoalDefinition? Definition { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("GoalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Goal")] // One2many
    public virtual ICollection<GamificationGoalWizard> GamificationGoalWizard { get; set; }

    // [Many2one]
    [ForeignKey("LineId")]
    public virtual GamificationChallengeLine? Line { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
